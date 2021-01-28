CREATE PROCEDURE [app].[Perm_UpdateBatch]
(
	@cie int,
	@json nvarchar(max)
)
AS
BEGIN
SET NOCOUNT ON
;

declare @perms table (id int, value int);
insert @perms
select id, value from OPENJSON(@json) with (id int, value int)
;

update app.Perm
set
	PermID = p.id,
	PermValue = p.value
from app.Perm np
inner join @perms p on p.id = np.PermID and np.CIE = @cie
where (PermValue <> p.value)
;

insert app.Perm (CIE, PermID, PermValue)
select
	@cie,
	p.id,
	p.value
from @perms p
left outer join app.Perm np on p.id = np.PermID and np.CIE = @cie
where (PermValue is null)
;

END