

Create Procedure [spI_Indexation_Livraison]

-- Inserts a new record in [Indexation_Livraison] table
(
  @IndexationID [int] -- for [Indexation_Livraison].[IndexationID] column
, @LivraisonID [int] -- for [Indexation_Livraison].[LivraisonID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Indexation_Livraison]
(
	  [IndexationID]
	, [LivraisonID]
)

Values
(
	  @IndexationID
	, @LivraisonID
)

Set NoCount Off

Return(0)


