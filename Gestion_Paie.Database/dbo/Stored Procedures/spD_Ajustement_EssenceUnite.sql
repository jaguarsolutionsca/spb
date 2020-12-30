CREATE Procedure [dbo].[spD_Ajustement_EssenceUnite]

-- Delete a specific record from table [Ajustement_EssenceUnite]

(
 @AjustementID [int] -- for [Ajustement_EssenceUnite].[AjustementID] column
,@EssenceID [varchar](6) -- for [Ajustement_EssenceUnite].[EssenceID] column
,@UniteID [varchar](6) -- for [Ajustement_EssenceUnite].[UniteID] column
,@Code [char](4) -- for [Ajustement_EssenceUnite].[Code] column
,@ContratID [varchar](10) = Null -- for [Ajustement_EssenceUnite].[ContratID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Ajustement_EssenceUnite]

Where
    ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))

Set NoCount Off

Return(@@RowCount)
