CREATE TABLE [dbo].[Livraison] (
    [ID]                                         INT            NOT NULL,
    [DateLivraison]                              SMALLDATETIME  NULL,
    [DatePaye]                                   SMALLDATETIME  NULL,
    [ContratID]                                  VARCHAR (10)   NULL,
    [UniteMesureID]                              VARCHAR (6)    NULL,
    [EssenceID]                                  VARCHAR (6)    NULL,
    [Sciage]                                     BIT            NULL,
    [NumeroFactureUsine]                         VARCHAR (25)   NULL,
    [DroitCoupeID]                               VARCHAR (15)   NULL,
    [EntentePaiementID]                          VARCHAR (15)   NULL,
    [TransporteurID]                             VARCHAR (15)   NULL,
    [VR]                                         VARCHAR (10)   NULL,
    [MasseLimite]                                FLOAT (53)     NULL,
    [VolumeBrut]                                 FLOAT (53)     NULL,
    [VolumeTare]                                 FLOAT (53)     NULL,
    [VolumeTransporte]                           FLOAT (53)     NULL,
    [VolumeSurcharge]                            FLOAT (53)     NULL,
    [VolumeAPayer]                               FLOAT (53)     NULL,
    [Annee]                                      INT            NULL,
    [Periode]                                    INT            NULL,
    [DateCalcul]                                 DATETIME       NULL,
    [Taux_Transporteur]                          FLOAT (53)     NULL,
    [Montant_Transporteur]                       FLOAT (53)     NULL,
    [Montant_Usine]                              FLOAT (53)     NULL,
    [Montant_Producteur1]                        FLOAT (53)     NULL,
    [Montant_Producteur2]                        FLOAT (53)     NULL,
    [Montant_Preleve_Plan_Conjoint]              FLOAT (53)     NULL,
    [Montant_Preleve_Fond_Roulement]             FLOAT (53)     NULL,
    [Montant_Preleve_Fond_Forestier]             FLOAT (53)     NULL,
    [Montant_Preleve_Divers]                     FLOAT (53)     NULL,
    [Montant_Surcharge]                          FLOAT (53)     NULL,
    [Montant_MiseEnCommun]                       REAL           NULL,
    [Facture]                                    BIT            NULL,
    [Producteur1_FactureID]                      INT            NULL,
    [Producteur2_FactureID]                      INT            NULL,
    [Transporteur_FactureID]                     INT            NULL,
    [Usine_FactureID]                            INT            NULL,
    [ErreurCalcul]                               BIT            NULL,
    [ErreurDescription]                          VARCHAR (4000) NULL,
    [LotID]                                      INT            NULL,
    [Taux_Transporteur_Override]                 BIT            NULL,
    [PaieTransporteur]                           BIT            NULL,
    [VolumeSurcharge_Override]                   BIT            NULL,
    [SurchargeManuel]                            BIT            NULL,
    [Code]                                       CHAR (4)       NULL,
    [NombrePermis]                               INT            NULL,
    [ZoneID]                                     VARCHAR (2)    NULL,
    [MunicipaliteID]                             VARCHAR (6)    NULL,
    [ChargeurID]                                 VARCHAR (15)   NULL,
    [Montant_Chargeur]                           FLOAT (53)     NULL,
    [Frais_ChargeurAuProducteur]                 FLOAT (53)     NULL,
    [Frais_ChargeurAuTransporteur]               FLOAT (53)     NULL,
    [Frais_AutresAuProducteur]                   FLOAT (53)     NULL,
    [Frais_AutresAuProducteurDescription]        VARCHAR (50)   NULL,
    [Frais_AutresAuProducteurTransportSciage]    FLOAT (53)     NULL,
    [Frais_AutresAuTransporteur]                 FLOAT (53)     NULL,
    [Frais_AutresAuTransporteurDescription]      VARCHAR (50)   NULL,
    [Frais_CompensationDeDeplacement]            FLOAT (53)     NULL,
    [Chargeur_FactureID]                         INT            NULL,
    [Commentaires_Producteur]                    VARCHAR (500)  NULL,
    [Commentaires_Transporteur]                  VARCHAR (500)  NULL,
    [Commentaires_Chargeur]                      VARCHAR (500)  NULL,
    [TauxChargeurAuProducteur]                   FLOAT (53)     NULL,
    [TauxChargeurAuTransporteur]                 FLOAT (53)     NULL,
    [Frais_AutresRevenusTransporteur]            FLOAT (53)     NULL,
    [Frais_AutresRevenusTransporteurDescription] VARCHAR (50)   NULL,
    [Frais_AutresRevenusProducteur]              FLOAT (53)     NULL,
    [Frais_AutresRevenusProducteurDescription]   VARCHAR (50)   NULL,
    [Montant_SurchargeProducteur]                FLOAT (53)     NULL,
    [KgVert_Brut]                                INT            NULL,
    [KgVert_Tare]                                INT            NULL,
    [KgVert_Net]                                 INT            NULL,
    [KgVert_Rejets]                              INT            NULL,
    [KgVert_Paye]                                INT            NULL,
    [Pourcent_Sec_Producteur]                    FLOAT (53)     NULL,
    [Pourcent_Sec_Producteur_Override]           BIT            NULL,
    [TMA_Producteur]                             FLOAT (53)     NULL,
    [Pourcent_Sec_Transport]                     FLOAT (53)     NULL,
    [Pourcent_Sec_Transport_Override]            BIT            NULL,
    [TMA_Transport]                              FLOAT (53)     NULL,
    [IsTMA]                                      BIT            NULL,
    [SuspendrePaiement]                          BIT            CONSTRAINT [DF__Livraison__Suspe__6279FC5B] DEFAULT (0) NOT NULL,
    [BonCommande]                                VARCHAR (25)   NULL,
    CONSTRAINT [PK_Livraison] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Livraison_Contrat] FOREIGN KEY ([ContratID]) REFERENCES [dbo].[Contrat] ([ID]),
    CONSTRAINT [FK_Livraison_Essence] FOREIGN KEY ([EssenceID]) REFERENCES [dbo].[Essence] ([ID]),
    CONSTRAINT [FK_Livraison_Facture] FOREIGN KEY ([Producteur1_FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_Facture1] FOREIGN KEY ([Producteur2_FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_Facture2] FOREIGN KEY ([Transporteur_FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_Facture3] FOREIGN KEY ([Chargeur_FactureID]) REFERENCES [dbo].[FactureFournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_FactureClient] FOREIGN KEY ([Usine_FactureID]) REFERENCES [dbo].[FactureClient] ([ID]),
    CONSTRAINT [FK_Livraison_Fournisseur] FOREIGN KEY ([DroitCoupeID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_Fournisseur1] FOREIGN KEY ([EntentePaiementID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_Fournisseur2] FOREIGN KEY ([TransporteurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_Fournisseur3] FOREIGN KEY ([ChargeurID]) REFERENCES [dbo].[Fournisseur] ([ID]),
    CONSTRAINT [FK_Livraison_Lot] FOREIGN KEY ([LotID]) REFERENCES [dbo].[Lot] ([ID]),
    CONSTRAINT [FK_Livraison_Municipalite_Zone] FOREIGN KEY ([ZoneID], [MunicipaliteID]) REFERENCES [dbo].[Municipalite_Zone] ([ID], [MunicipaliteID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Livraison_Periode] FOREIGN KEY ([Annee], [Periode]) REFERENCES [dbo].[Periode] ([Annee], [SemaineNo]),
    CONSTRAINT [FK_Livraison_Permit] FOREIGN KEY ([ID]) REFERENCES [dbo].[Permit] ([ID]),
    CONSTRAINT [FK_Livraison_UniteMesure] FOREIGN KEY ([UniteMesureID]) REFERENCES [dbo].[UniteMesure] ([ID]) ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [ix_Livraison_Usine_FactureID]
    ON [dbo].[Livraison]([Usine_FactureID] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_Livraison_Poducteur2_factureID]
    ON [dbo].[Livraison]([Producteur2_FactureID] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_Livraison_Producteur1_FactureID]
    ON [dbo].[Livraison]([Producteur1_FactureID] ASC);


GO
CREATE NONCLUSTERED INDEX [ix_Livraison_Facture_TransporteurID]
    ON [dbo].[Livraison]([Facture] ASC, [TransporteurID] ASC)
    INCLUDE([ID], [ContratID], [Annee], [Periode], [ZoneID], [MunicipaliteID]);


GO
CREATE NONCLUSTERED INDEX [ix_Livraison_Contrat_Facture]
    ON [dbo].[Livraison]([ContratID] ASC, [Facture] ASC)
    INCLUDE([ID], [TransporteurID]);

