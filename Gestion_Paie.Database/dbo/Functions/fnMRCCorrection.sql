

Create Function [fnMRCCorrection]
(
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [CodeMRC]
,[CodeCIEL]

From [dbo].[MRCCorrection]

)


