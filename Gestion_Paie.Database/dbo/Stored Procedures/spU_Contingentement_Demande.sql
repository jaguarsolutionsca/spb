
CREATE Procedure [spU_Contingentement_Demande]

-- Update an existing record in [Contingentement_Demande] table

(
  @ID [int] -- for [Contingentement_Demande].[ID] column
, @Annee [int] = Null -- for [Contingentement_Demande].[Annee] column
, @ConsiderNull_Annee bit = 0
, @ProducteurID [varchar](15) = Null -- for [Contingentement_Demande].[ProducteurID] column
, @ConsiderNull_ProducteurID bit = 0
, @TransporteurID [varchar](15) = Null -- for [Contingentement_Demande].[TransporteurID] column
, @ConsiderNull_TransporteurID bit = 0
, @Superficie_Boisee [real] = Null -- for [Contingentement_Demande].[Superficie_Boisee] column
, @ConsiderNull_Superficie_Boisee bit = 0
, @Remarques [varchar](2000) = Null -- for [Contingentement_Demande].[Remarques] column
, @ConsiderNull_Remarques bit = 0
, @DateModification [smalldatetime] = Null -- for [Contingentement_Demande].[DateModification] column
, @ConsiderNull_DateModification bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Annee Is Null
	Set @ConsiderNull_Annee = 0

If @ConsiderNull_ProducteurID Is Null
	Set @ConsiderNull_ProducteurID = 0

If @ConsiderNull_TransporteurID Is Null
	Set @ConsiderNull_TransporteurID = 0

If @ConsiderNull_Superficie_Boisee Is Null
	Set @ConsiderNull_Superficie_Boisee = 0

If @ConsiderNull_Remarques Is Null
	Set @ConsiderNull_Remarques = 0

If @ConsiderNull_DateModification Is Null
	Set @ConsiderNull_DateModification = 0


Update [dbo].[Contingentement_Demande]

Set
	 [Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[ProducteurID] = Case @ConsiderNull_ProducteurID When 0 Then IsNull(@ProducteurID, [ProducteurID]) When 1 Then @ProducteurID End
	,[TransporteurID] = Case @ConsiderNull_TransporteurID When 0 Then IsNull(@TransporteurID, [TransporteurID]) When 1 Then @TransporteurID End
	,[Superficie_Boisee] = Case @ConsiderNull_Superficie_Boisee When 0 Then IsNull(@Superficie_Boisee, [Superficie_Boisee]) When 1 Then @Superficie_Boisee End
	,[Remarques] = Case @ConsiderNull_Remarques When 0 Then IsNull(@Remarques, [Remarques]) When 1 Then @Remarques End
	,[DateModification] = Case @ConsiderNull_DateModification When 0 Then IsNull(@DateModification, [DateModification]) When 1 Then @DateModification End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)

