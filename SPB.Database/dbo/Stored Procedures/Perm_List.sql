CREATE PROCEDURE [dbo].[Perm_List]
(
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;

--
-- Every change done here must also be applied in security.ts
--
select
	JSON_QUERY((
		select 
			CIE [cie],
			Name [title]
		from app.Company
		where CIE = @cie
		for json AUTO, WITHOUT_ARRAY_WRAPPER
	)) as [xtra]
	,
	JSON_QUERY((
		select 
			grp.Description [stnKind],
			ro.Description [role2],
			CAST(ro.Code as int) [role_bit]
		from app.PermMeta ro
		inner join app.PermMeta grp on grp.ID = ro.ParentID
		where
			ro.Groupe = 'ROLE2EX' and (ro.[Key] is null or ro.[Key] <> 'SUPPORT')
		order by grp.SortOrder, ro.SortOrder
		for json AUTO
	)) as [roles]
	,
	JSON_QUERY((
		select 
			grp.Code [groupID],
			grp.Description [groupe],
			item.Description [description], 
			item.code [permID],
			perm.PermValue [permValue]
		from app.PermMeta item
		inner join app.PermMeta grp on grp.ID = item.ParentID
		left outer join app.Perm perm on perm.PermID = item.code and perm.CIE = @cie
		where
			item.Groupe = 'PERM-ITEM' and
			grp.Groupe = 'PERM-GROUP'
		order by grp.SortOrder, item.code
		for json AUTO
	)) as [items]

	for json PATH, WITHOUT_ARRAY_WRAPPER
;

END