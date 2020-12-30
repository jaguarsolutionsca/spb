


CREATE Procedure jag_ListView_Fournisseur

(
 @ID [varchar](15) = Null -- for [Fournisseur].[ID] column
,@TypeFournisseurID [char](1) = Null -- for [Fournisseur].[TypeFournisseurID] column
,@PaysID [varchar](2) = Null -- for [Fournisseur].[PaysID] column
,@InstitutionBanquaireID [varchar](3) = Null -- for [Fournisseur].[InstitutionBanquaireID] column
,@Actif bit = null
)

-- Returns the number of records found

As

IF (@TypeFournisseurID = 'P')
BEGIN
	Select
	LTRIM(F.[Nom]) AS [Nom]
	,F.[ID]
	,LTRIM(RTRIM(F.[Rue])) AS [Rue]
	--,[Fournisseur_Records].[CleTri]
	,(CASE WHEN IsNumeric(F.[ID]) = 1 THEN CONVERT(bigint,CONVERT(FLOAT,F.[ID])) ELSE 0 END) AS [CleTrie]
	--,[Fournisseur_Records].[TypeFournisseurID]
	,(CASE WHEN (F.[Telephone_Poste] IS NOT NULL) 
		THEN 
			(dbo.jag_Convert_Phone(F.[Telephone]) 
			+ ' (poste:' + F.[Telephone_Poste] + ')') 
		ELSE 
			(dbo.jag_Convert_Phone(F.[Telephone])) 
		END) 
		AS [Telephone]	
	,F.[No_membre]
	,F.[Resident]
	,F.Rep_Nom as Representant
	,F.[Actif]

	From Fournisseur F
	WHERE ((@ID IS NULL) OR (F.[ID] = @ID))
	AND ((@PaysID IS NULL) OR (F.PaysID = @PaysID))
	AND ((@InstitutionBanquaireID IS NULL) OR (F.InstitutionBanquaireID = @InstitutionBanquaireID))
	AND ((@TypeFournisseurID IS NULL) OR 
	((@TypeFournisseurID = 'P') and (IsProducteur = 1)) OR
	((@TypeFournisseurID = 'T') and (IsTransporteur = 1)) OR
	((@TypeFournisseurID = 'C') and (IsChargeur = 1)) OR
	((@TypeFournisseurID = 'A') and (IsAutre = 1)))
	AND ((@Actif is null) or (F.[Actif] = @Actif))
	order by F.[Nom]
END
ELSE
BEGIN
	Select
	LTRIM(F.[Nom]) AS [Nom]
	,F.[ID]
	--,[Fournisseur_Records].[TypeFournisseurID]
	,(CASE WHEN (F.[Telephone_Poste] IS NOT NULL) 
		THEN 
			(dbo.jag_Convert_Phone(F.[Telephone]) 
			+ ' (poste:' + F.[Telephone_Poste] + ')') 
		ELSE 
			(dbo.jag_Convert_Phone(F.[Telephone])) 
		END) 
		AS [Telephone]	
	,F.[No_membre]
	,F.[Resident]
	,F.Rep_Nom as Representant
	,F.[Actif]

	From Fournisseur F
	WHERE ((@ID IS NULL) OR (F.[ID] = @ID))
	AND ((@PaysID IS NULL) OR (F.PaysID = @PaysID))
	AND ((@InstitutionBanquaireID IS NULL) OR (F.InstitutionBanquaireID = @InstitutionBanquaireID))
	AND ((@TypeFournisseurID IS NULL) OR 
	((@TypeFournisseurID = 'P') and (IsProducteur = 1)) OR
	((@TypeFournisseurID = 'T') and (IsTransporteur = 1)) OR
	((@TypeFournisseurID = 'C') and (IsChargeur = 1)) OR
	((@TypeFournisseurID = 'A') and (IsAutre = 1)))
	AND ((@Actif is null) or (F.[Actif] = @Actif))
	order by F.[Nom]
END

Return(@@RowCount)




