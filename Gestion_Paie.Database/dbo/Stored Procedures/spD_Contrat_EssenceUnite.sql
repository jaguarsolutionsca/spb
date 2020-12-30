

Create Procedure [spD_Contrat_EssenceUnite]

-- Delete a specific record from table [Contrat_EssenceUnite]

(
 @ContratID [varchar](10) -- for [Contrat_EssenceUnite].[ContratID] column
,@EssenceID [varchar](6) -- for [Contrat_EssenceUnite].[EssenceID] column
,@UniteID [varchar](6) -- for [Contrat_EssenceUnite].[UniteID] column
,@Code [char](4) -- for [Contrat_EssenceUnite].[Code] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Contrat_EssenceUnite]

Where
    ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@Code Is Null) Or ([Code] = @Code))

Set NoCount Off

Return(@@RowCount)


