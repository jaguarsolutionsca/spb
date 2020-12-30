

CREATE Procedure [spD_Indexation_EssenceUnite]

-- Delete a specific record from table [Indexation_EssenceUnite]

(
 @ID [int] -- for [Indexation_EssenceUnite].[ID] column
,@IndexationID [int] = Null -- for [Indexation_EssenceUnite].[IndexationID] column
,@ContratID [varchar](10) = Null -- for [Indexation_EssenceUnite].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Indexation_EssenceUnite].[EssenceID] column
,@Code [char](4) = Null -- for [Indexation_EssenceUnite].[Code] column
,@UniteID [varchar](6) = Null -- for [Indexation_EssenceUnite].[UniteID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Indexation_EssenceUnite]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))

Set NoCount Off

Return(@@RowCount)


