

Create Procedure [spI_MRCCorrection]

-- Inserts a new record in [MRCCorrection] table
(
  @CodeMRC [varchar](15) = Null  -- for [MRCCorrection].[CodeMRC] column
, @CodeCIEL [varchar](15) = Null  -- for [MRCCorrection].[CodeCIEL] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[MRCCorrection]
(
	  [CodeMRC]
	, [CodeCIEL]
)

Values
(
	  @CodeMRC
	, @CodeCIEL
)

Set NoCount Off

Return(0)


