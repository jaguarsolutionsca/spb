CREATE PROCEDURE [dbo].[spS_Essence_Unite_SelectDisplay]
@EssenceID VARCHAR (6)=Null, @UniteID VARCHAR (6)=Null, @ReturnXML BIT=0
AS
If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Essence_Unite_Records].[EssenceID]
		,[Essence_Unite_Records].[EssenceID_Display]
		,[Essence_Unite_Records].[UniteID]
		,[Essence_Unite_Records].[UniteID_Display]
		,[Essence_Unite_Records].[Facteur_M3app]
		,[Essence_Unite_Records].[Facteur_M3sol]
		,[Essence_Unite_Records].[Facteur_FPBQ]
		,[Essence_Unite_Records].[Actif]
		,[Essence_Unite_Records].[Preleve_plan_conjoint]
		,[Essence_Unite_Records].[Preleve_plan_conjoint_Override]
		,[Essence_Unite_Records].[Preleve_fond_roulement]
		,[Essence_Unite_Records].[Preleve_fond_roulement_Override]
		,[Essence_Unite_Records].[Preleve_fond_forestier]
		,[Essence_Unite_Records].[Preleve_fond_forestier_Override]
		,[Essence_Unite_Records].[Preleve_divers]
		,[Essence_Unite_Records].[Preleve_divers_Override]
		,[Essence_Unite_Records].[UseMontant]

		From [fnEssence_Unite_SelectDisplay](@EssenceID, @UniteID) As [Essence_Unite_Records]
	End

Else

	Begin
		Select

		 [Essence_Unite_Records].[EssenceID]
		,[Essence_Unite_Records].[EssenceID_Display]
		,[Essence_Unite_Records].[UniteID]
		,[Essence_Unite_Records].[UniteID_Display]
		,[Essence_Unite_Records].[Facteur_M3app]
		,[Essence_Unite_Records].[Facteur_M3sol]
		,[Essence_Unite_Records].[Facteur_FPBQ]
		,[Essence_Unite_Records].[Actif]
		,[Essence_Unite_Records].[Preleve_plan_conjoint]
		,[Essence_Unite_Records].[Preleve_plan_conjoint_Override]
		,[Essence_Unite_Records].[Preleve_fond_roulement]
		,[Essence_Unite_Records].[Preleve_fond_roulement_Override]
		,[Essence_Unite_Records].[Preleve_fond_forestier]
		,[Essence_Unite_Records].[Preleve_fond_forestier_Override]
		,[Essence_Unite_Records].[Preleve_divers]
		,[Essence_Unite_Records].[Preleve_divers_Override]
		,[Essence_Unite_Records].[UseMontant]

		From [fnEssence_Unite_SelectDisplay](@EssenceID, @UniteID) As [Essence_Unite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


