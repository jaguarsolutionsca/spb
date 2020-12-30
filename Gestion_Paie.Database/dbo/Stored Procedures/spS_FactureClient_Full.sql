

Create Procedure [spS_FactureClient_Full]

/*
Retrieve specific records from the [FactureClient] table, as well as all its foreign tables, depending on the input parameters you supply:
	[TypeFacture] (via [TypeFacture])
	[TypeInvoiceClientAcomba] (via [TypeInvoiceClientAcomba])
	[Usine] (via [ClientID])
	[Usine] (via [PayerAID])
	[FactureStatus] (via [Status])
*/

(
 @ID [int] = Null -- for [FactureClient].[ID] column
,@TypeFacture [char](1) = Null -- for [FactureClient].[TypeFacture] column
,@TypeInvoiceClientAcomba [int] = Null -- for [FactureClient].[TypeInvoiceClientAcomba] column
,@ClientID [varchar](6) = Null -- for [FactureClient].[ClientID] column
,@PayerAID [varchar](6) = Null -- for [FactureClient].[PayerAID] column
,@Status [varchar](15) = Null -- for [FactureClient].[Status] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [FactureClient_Records].[ID]
		,[FactureClient_Records].[NoFacture]
		,[FactureClient_Records].[DateFacture]
		,[FactureClient_Records].[Annee]
		,[FactureClient_Records].[TypeFacture]
		,[FactureClient_Records].[TypeInvoiceClientAcomba]
		,[FactureClient_Records].[ClientID]
		,[FactureClient_Records].[PayerAID]
		,[FactureClient_Records].[Montant_Total]
		,[FactureClient_Records].[Montant_TPS]
		,[FactureClient_Records].[Montant_TVQ]
		,[FactureClient_Records].[Description]
		,[FactureClient_Records].[Status]
		,[FactureClient_Records].[StatusDescription]
		,[FactureClient_Records].[DateFactureAcomba]
		,[FactureClient_Records].[TypeFacture_ID]
		,[FactureClient_Records].[TypeFacture_Description]
		,[FactureClient_Records].[TypeFacture_FactureDescriptionMask]
		,[FactureClient_Records].[TypeInvoiceClientAcomba_ID]
		,[FactureClient_Records].[TypeInvoiceClientAcomba_Description]
		,[FactureClient_Records].[ClientID_ID]
		,[FactureClient_Records].[ClientID_Description]
		,[FactureClient_Records].[ClientID_UtilisationID]
		,[FactureClient_Records].[ClientID_Paye_producteur]
		,[FactureClient_Records].[ClientID_Paye_transporteur]
		,[FactureClient_Records].[ClientID_Specification]
		,[FactureClient_Records].[ClientID_Compte_a_recevoir]
		,[FactureClient_Records].[ClientID_Compte_ajustement]
		,[FactureClient_Records].[ClientID_Compte_transporteur]
		,[FactureClient_Records].[ClientID_Compte_producteur]
		,[FactureClient_Records].[ClientID_Compte_preleve_plan_conjoint]
		,[FactureClient_Records].[ClientID_Compte_preleve_fond_roulement]
		,[FactureClient_Records].[ClientID_Compte_preleve_fond_forestier]
		,[FactureClient_Records].[ClientID_Compte_preleve_divers]
		,[FactureClient_Records].[ClientID_Compte_mise_en_commun]
		,[FactureClient_Records].[ClientID_Compte_surcharge]
		,[FactureClient_Records].[ClientID_Compte_indexation_carburant]
		,[FactureClient_Records].[ClientID_Actif]
		,[FactureClient_Records].[ClientID_NePaiePasTPS]
		,[FactureClient_Records].[ClientID_NePaiePasTVQ]
		,[FactureClient_Records].[ClientID_NoTPS]
		,[FactureClient_Records].[ClientID_NoTVQ]
		,[FactureClient_Records].[ClientID_Compte_chargeur]
		,[FactureClient_Records].[ClientID_UsineGestionVolume]
		,[FactureClient_Records].[ClientID_AuSoinsDe]
		,[FactureClient_Records].[ClientID_Rue]
		,[FactureClient_Records].[ClientID_Ville]
		,[FactureClient_Records].[ClientID_PaysID]
		,[FactureClient_Records].[ClientID_Code_postal]
		,[FactureClient_Records].[ClientID_Telephone]
		,[FactureClient_Records].[ClientID_Telephone_Poste]
		,[FactureClient_Records].[ClientID_Telecopieur]
		,[FactureClient_Records].[ClientID_Telephone2]
		,[FactureClient_Records].[ClientID_Telephone2_Desc]
		,[FactureClient_Records].[ClientID_Telephone2_Poste]
		,[FactureClient_Records].[ClientID_Telephone3]
		,[FactureClient_Records].[ClientID_Telephone3_Desc]
		,[FactureClient_Records].[ClientID_Telephone3_Poste]
		,[FactureClient_Records].[ClientID_Email]
		,[FactureClient_Records].[PayerAID_ID]
		,[FactureClient_Records].[PayerAID_Description]
		,[FactureClient_Records].[PayerAID_UtilisationID]
		,[FactureClient_Records].[PayerAID_Paye_producteur]
		,[FactureClient_Records].[PayerAID_Paye_transporteur]
		,[FactureClient_Records].[PayerAID_Specification]
		,[FactureClient_Records].[PayerAID_Compte_a_recevoir]
		,[FactureClient_Records].[PayerAID_Compte_ajustement]
		,[FactureClient_Records].[PayerAID_Compte_transporteur]
		,[FactureClient_Records].[PayerAID_Compte_producteur]
		,[FactureClient_Records].[PayerAID_Compte_preleve_plan_conjoint]
		,[FactureClient_Records].[PayerAID_Compte_preleve_fond_roulement]
		,[FactureClient_Records].[PayerAID_Compte_preleve_fond_forestier]
		,[FactureClient_Records].[PayerAID_Compte_preleve_divers]
		,[FactureClient_Records].[PayerAID_Compte_mise_en_commun]
		,[FactureClient_Records].[PayerAID_Compte_surcharge]
		,[FactureClient_Records].[PayerAID_Compte_indexation_carburant]
		,[FactureClient_Records].[PayerAID_Actif]
		,[FactureClient_Records].[PayerAID_NePaiePasTPS]
		,[FactureClient_Records].[PayerAID_NePaiePasTVQ]
		,[FactureClient_Records].[PayerAID_NoTPS]
		,[FactureClient_Records].[PayerAID_NoTVQ]
		,[FactureClient_Records].[PayerAID_Compte_chargeur]
		,[FactureClient_Records].[PayerAID_UsineGestionVolume]
		,[FactureClient_Records].[PayerAID_AuSoinsDe]
		,[FactureClient_Records].[PayerAID_Rue]
		,[FactureClient_Records].[PayerAID_Ville]
		,[FactureClient_Records].[PayerAID_PaysID]
		,[FactureClient_Records].[PayerAID_Code_postal]
		,[FactureClient_Records].[PayerAID_Telephone]
		,[FactureClient_Records].[PayerAID_Telephone_Poste]
		,[FactureClient_Records].[PayerAID_Telecopieur]
		,[FactureClient_Records].[PayerAID_Telephone2]
		,[FactureClient_Records].[PayerAID_Telephone2_Desc]
		,[FactureClient_Records].[PayerAID_Telephone2_Poste]
		,[FactureClient_Records].[PayerAID_Telephone3]
		,[FactureClient_Records].[PayerAID_Telephone3_Desc]
		,[FactureClient_Records].[PayerAID_Telephone3_Poste]
		,[FactureClient_Records].[PayerAID_Email]
		,[FactureClient_Records].[Status_ID]

		From [fnFactureClient_Full](@ID, @TypeFacture, @TypeInvoiceClientAcomba, @ClientID, @PayerAID, @Status) As [FactureClient_Records]
	End

Else

	Begin
		Select

		 [FactureClient_Records].[ID]
		,[FactureClient_Records].[NoFacture]
		,[FactureClient_Records].[DateFacture]
		,[FactureClient_Records].[Annee]
		,[FactureClient_Records].[TypeFacture]
		,[FactureClient_Records].[TypeInvoiceClientAcomba]
		,[FactureClient_Records].[ClientID]
		,[FactureClient_Records].[PayerAID]
		,[FactureClient_Records].[Montant_Total]
		,[FactureClient_Records].[Montant_TPS]
		,[FactureClient_Records].[Montant_TVQ]
		,[FactureClient_Records].[Description]
		,[FactureClient_Records].[Status]
		,[FactureClient_Records].[StatusDescription]
		,[FactureClient_Records].[DateFactureAcomba]
		,[FactureClient_Records].[TypeFacture_ID]
		,[FactureClient_Records].[TypeFacture_Description]
		,[FactureClient_Records].[TypeFacture_FactureDescriptionMask]
		,[FactureClient_Records].[TypeInvoiceClientAcomba_ID]
		,[FactureClient_Records].[TypeInvoiceClientAcomba_Description]
		,[FactureClient_Records].[ClientID_ID]
		,[FactureClient_Records].[ClientID_Description]
		,[FactureClient_Records].[ClientID_UtilisationID]
		,[FactureClient_Records].[ClientID_Paye_producteur]
		,[FactureClient_Records].[ClientID_Paye_transporteur]
		,[FactureClient_Records].[ClientID_Specification]
		,[FactureClient_Records].[ClientID_Compte_a_recevoir]
		,[FactureClient_Records].[ClientID_Compte_ajustement]
		,[FactureClient_Records].[ClientID_Compte_transporteur]
		,[FactureClient_Records].[ClientID_Compte_producteur]
		,[FactureClient_Records].[ClientID_Compte_preleve_plan_conjoint]
		,[FactureClient_Records].[ClientID_Compte_preleve_fond_roulement]
		,[FactureClient_Records].[ClientID_Compte_preleve_fond_forestier]
		,[FactureClient_Records].[ClientID_Compte_preleve_divers]
		,[FactureClient_Records].[ClientID_Compte_mise_en_commun]
		,[FactureClient_Records].[ClientID_Compte_surcharge]
		,[FactureClient_Records].[ClientID_Compte_indexation_carburant]
		,[FactureClient_Records].[ClientID_Actif]
		,[FactureClient_Records].[ClientID_NePaiePasTPS]
		,[FactureClient_Records].[ClientID_NePaiePasTVQ]
		,[FactureClient_Records].[ClientID_NoTPS]
		,[FactureClient_Records].[ClientID_NoTVQ]
		,[FactureClient_Records].[ClientID_Compte_chargeur]
		,[FactureClient_Records].[ClientID_UsineGestionVolume]
		,[FactureClient_Records].[ClientID_AuSoinsDe]
		,[FactureClient_Records].[ClientID_Rue]
		,[FactureClient_Records].[ClientID_Ville]
		,[FactureClient_Records].[ClientID_PaysID]
		,[FactureClient_Records].[ClientID_Code_postal]
		,[FactureClient_Records].[ClientID_Telephone]
		,[FactureClient_Records].[ClientID_Telephone_Poste]
		,[FactureClient_Records].[ClientID_Telecopieur]
		,[FactureClient_Records].[ClientID_Telephone2]
		,[FactureClient_Records].[ClientID_Telephone2_Desc]
		,[FactureClient_Records].[ClientID_Telephone2_Poste]
		,[FactureClient_Records].[ClientID_Telephone3]
		,[FactureClient_Records].[ClientID_Telephone3_Desc]
		,[FactureClient_Records].[ClientID_Telephone3_Poste]
		,[FactureClient_Records].[ClientID_Email]
		,[FactureClient_Records].[PayerAID_ID]
		,[FactureClient_Records].[PayerAID_Description]
		,[FactureClient_Records].[PayerAID_UtilisationID]
		,[FactureClient_Records].[PayerAID_Paye_producteur]
		,[FactureClient_Records].[PayerAID_Paye_transporteur]
		,[FactureClient_Records].[PayerAID_Specification]
		,[FactureClient_Records].[PayerAID_Compte_a_recevoir]
		,[FactureClient_Records].[PayerAID_Compte_ajustement]
		,[FactureClient_Records].[PayerAID_Compte_transporteur]
		,[FactureClient_Records].[PayerAID_Compte_producteur]
		,[FactureClient_Records].[PayerAID_Compte_preleve_plan_conjoint]
		,[FactureClient_Records].[PayerAID_Compte_preleve_fond_roulement]
		,[FactureClient_Records].[PayerAID_Compte_preleve_fond_forestier]
		,[FactureClient_Records].[PayerAID_Compte_preleve_divers]
		,[FactureClient_Records].[PayerAID_Compte_mise_en_commun]
		,[FactureClient_Records].[PayerAID_Compte_surcharge]
		,[FactureClient_Records].[PayerAID_Compte_indexation_carburant]
		,[FactureClient_Records].[PayerAID_Actif]
		,[FactureClient_Records].[PayerAID_NePaiePasTPS]
		,[FactureClient_Records].[PayerAID_NePaiePasTVQ]
		,[FactureClient_Records].[PayerAID_NoTPS]
		,[FactureClient_Records].[PayerAID_NoTVQ]
		,[FactureClient_Records].[PayerAID_Compte_chargeur]
		,[FactureClient_Records].[PayerAID_UsineGestionVolume]
		,[FactureClient_Records].[PayerAID_AuSoinsDe]
		,[FactureClient_Records].[PayerAID_Rue]
		,[FactureClient_Records].[PayerAID_Ville]
		,[FactureClient_Records].[PayerAID_PaysID]
		,[FactureClient_Records].[PayerAID_Code_postal]
		,[FactureClient_Records].[PayerAID_Telephone]
		,[FactureClient_Records].[PayerAID_Telephone_Poste]
		,[FactureClient_Records].[PayerAID_Telecopieur]
		,[FactureClient_Records].[PayerAID_Telephone2]
		,[FactureClient_Records].[PayerAID_Telephone2_Desc]
		,[FactureClient_Records].[PayerAID_Telephone2_Poste]
		,[FactureClient_Records].[PayerAID_Telephone3]
		,[FactureClient_Records].[PayerAID_Telephone3_Desc]
		,[FactureClient_Records].[PayerAID_Telephone3_Poste]
		,[FactureClient_Records].[PayerAID_Email]
		,[FactureClient_Records].[Status_ID]

		From [fnFactureClient_Full](@ID, @TypeFacture, @TypeInvoiceClientAcomba, @ClientID, @PayerAID, @Status) As [FactureClient_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


