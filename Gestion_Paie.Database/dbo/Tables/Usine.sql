CREATE TABLE [dbo].[Usine] (
    [ID]                            VARCHAR (6)  NOT NULL,
    [Description]                   VARCHAR (50) NULL,
    [UtilisationID]                 INT          NULL,
    [Paye_producteur]               BIT          NULL,
    [Paye_transporteur]             BIT          NULL,
    [Specification]                 TEXT         NULL,
    [Compte_a_recevoir]             INT          NULL,
    [Compte_ajustement]             INT          NULL,
    [Compte_transporteur]           INT          NULL,
    [Compte_producteur]             INT          NULL,
    [Compte_preleve_plan_conjoint]  INT          NULL,
    [Compte_preleve_fond_roulement] INT          NULL,
    [Compte_preleve_fond_forestier] INT          NULL,
    [Compte_preleve_divers]         INT          NULL,
    [Compte_mise_en_commun]         INT          NULL,
    [Compte_surcharge]              INT          NULL,
    [Compte_indexation_carburant]   INT          NULL,
    [Actif]                         BIT          NULL,
    [NePaiePasTPS]                  BIT          NULL,
    [NePaiePasTVQ]                  BIT          NULL,
    [NoTPS]                         VARCHAR (25) NULL,
    [NoTVQ]                         VARCHAR (25) NULL,
    [Compte_chargeur]               INT          NULL,
    [UsineGestionVolume]            BIT          NULL,
    [AuSoinsDe]                     VARCHAR (30) NULL,
    [Rue]                           VARCHAR (30) NULL,
    [Ville]                         VARCHAR (30) NULL,
    [PaysID]                        VARCHAR (2)  NULL,
    [Code_postal]                   VARCHAR (7)  NULL,
    [Telephone]                     VARCHAR (12) NULL,
    [Telephone_Poste]               VARCHAR (4)  NULL,
    [Telecopieur]                   VARCHAR (12) NULL,
    [Telephone2]                    VARCHAR (12) NULL,
    [Telephone2_Desc]               VARCHAR (20) NULL,
    [Telephone2_Poste]              VARCHAR (4)  NULL,
    [Telephone3]                    VARCHAR (12) NULL,
    [Telephone3_Desc]               VARCHAR (20) NULL,
    [Telephone3_Poste]              VARCHAR (4)  NULL,
    [Email]                         VARCHAR (80) NULL,
    CONSTRAINT [PK_Usine] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Usine_Compte] FOREIGN KEY ([Compte_a_recevoir]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte1] FOREIGN KEY ([Compte_ajustement]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte10] FOREIGN KEY ([Compte_indexation_carburant]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte2] FOREIGN KEY ([Compte_transporteur]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte3] FOREIGN KEY ([Compte_producteur]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte4] FOREIGN KEY ([Compte_preleve_plan_conjoint]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte5] FOREIGN KEY ([Compte_preleve_fond_roulement]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte6] FOREIGN KEY ([Compte_preleve_fond_forestier]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte7] FOREIGN KEY ([Compte_preleve_divers]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte8] FOREIGN KEY ([Compte_mise_en_commun]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Compte9] FOREIGN KEY ([Compte_surcharge]) REFERENCES [dbo].[Compte] ([ID]),
    CONSTRAINT [FK_Usine_Pays] FOREIGN KEY ([PaysID]) REFERENCES [dbo].[Pays] ([ID]),
    CONSTRAINT [FK_Usine_UsineUtilisation] FOREIGN KEY ([UtilisationID]) REFERENCES [dbo].[UsineUtilisation] ([ID])
);


GO


CREATE TRIGGER TrigUsine_Delete
ON dbo.Usine
FOR DELETE 
AS

DECLARE @TriggerEnabled BIT
SET @TriggerEnabled = 1
IF ((SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'UtiliseLeSychronisateurDirect') = 'true')
BEGIN
	SET @TriggerEnabled = 0
END
IF (@TriggerEnabled = 0) RETURN

-- Get the ID of the Deleted Row
DECLARE @ID CHAR(6)
Select @ID  = (Select ID From Deleted)


	
		-- generate xml	
		declare @Path varchar(8000)

		exec ForXMLAuto 0, @ID, @Path OUTPUT
		
		-- Update FournisseurAcomba avec le XML
		exec jag_Delete_Acomba_Client @ID, @Path

-- Return
return











GO


CREATE TRIGGER TrigUsine_Insert
ON dbo.Usine
FOR Insert
AS

DECLARE @TriggerEnabled BIT
SET @TriggerEnabled = 1
IF ((SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'UtiliseLeSychronisateurDirect') = 'true')
BEGIN
	SET @TriggerEnabled = 0
END
IF (@TriggerEnabled = 0) RETURN

-- Get the ID of the Deleted Row
DECLARE @ID							VARCHAR(6)

-- Initialize Variables
SELECT @ID							= (select ID FROM Inserted)

		-- generate xml	
		declare @Path varchar(8000)

		exec ForXMLAuto 0, @ID, @Path OUTPUT
		
		-- Update FournisseurAcomba avec le XML
		exec jag_Update_Acomba_Client @ID, @Path


-- Return
return










GO


CREATE TRIGGER TrigUsine_Update
ON dbo.Usine
FOR UPDATE
AS

DECLARE @TriggerEnabled BIT
SET @TriggerEnabled = 1
IF ((SELECT [Value] FROM jag_SystemEx WHERE [Name] = 'UtiliseLeSychronisateurDirect') = 'true')
BEGIN
	SET @TriggerEnabled = 0
END
IF (@TriggerEnabled = 0) RETURN

-- Get the ID of the Deleted Row
DECLARE @ID							VARCHAR(6)

-- Initialize Variables
SELECT @ID							= (select ID FROM Inserted)


		-- generate xml	
		declare @Path varchar(8000)

		exec ForXMLAuto 0, @ID, @Path OUTPUT
		
		-- Update FournisseurAcomba avec le XML
		exec jag_Update_Acomba_Client @ID, @Path


-- Return
return





