

CREATE FUNCTION dbo.jag_HTMLEncode
	(
	
	@XMLString varchar(2000)
	
	)
RETURNS varchar(2000)
AS

BEGIN
	declare @XMLStringReturn varchar(2000)
	
	set @XMLString = replace(@XMLString, '&', '&amp;')
	set @XMLString = replace(@XMLString, '<', '&lt;')
	set @XMLString = replace(@XMLString, '>', '&gt;')

	set @XMLString = replace(@XMLString, 'À', '&#192;')  
	set @XMLString = replace(@XMLString, 'à', '&#224;')  
	set @XMLString = replace(@XMLString, 'Á', '&#193;')  
	set @XMLString = replace(@XMLString, 'á', '&#225;')  
	set @XMLString = replace(@XMLString, 'Â', '&#194;') 
	set @XMLString = replace(@XMLString, 'â', '&#226;')  
	set @XMLString = replace(@XMLString, 'Ä', '&#196;') 
	set @XMLString = replace(@XMLString, 'ä', '&#228;')  
	set @XMLString = replace(@XMLString, 'É', '&#201;') 
	set @XMLString = replace(@XMLString, 'é', '&#223;')  
	set @XMLString = replace(@XMLString, 'È', '&#200;')   
	set @XMLString = replace(@XMLString, 'è', '&#232;')  
	set @XMLString = replace(@XMLString, 'Ê', '&#202;')  
	set @XMLString = replace(@XMLString, 'ê', '&#234;')   
	set @XMLString = replace(@XMLString, 'Ë', '&#203;')   
	set @XMLString = replace(@XMLString, 'ë', '&#235;')   
	set @XMLString = replace(@XMLString, 'Î', '&#206;')   
	set @XMLString = replace(@XMLString, 'î', '&#238;')   
	set @XMLString = replace(@XMLString, 'Ï', '&#207;')   
	set @XMLString = replace(@XMLString, 'ï', '&#239;')   
	set @XMLString = replace(@XMLString, 'Ô', '&#212;')  
	set @XMLString = replace(@XMLString, 'ô', '&#244;')    
	set @XMLString = replace(@XMLString, 'Ò', '&#210;')
	set @XMLString = replace(@XMLString, 'ò', '&#242;')
	set @XMLString = replace(@XMLString, 'Ô', '&#212;') 
	set @XMLString = replace(@XMLString, 'ô', '&#244;') 
	set @XMLString = replace(@XMLString, 'Ö', '&#214;') 
	set @XMLString = replace(@XMLString, 'ö', '&#246;') 
	set @XMLString = replace(@XMLString, 'Ÿ', '&#159;') 
	set @XMLString = replace(@XMLString, 'ÿ', '&#255;')  
	set @XMLString = replace(@XMLString, 'Ç', '&#199;')  
	set @XMLString = replace(@XMLString, 'ç', '&#231;')  
	set @XMLString = replace(@XMLString, '«', '&#171;') 
	set @XMLString = replace(@XMLString, '»', '&#187;') 
	set @XMLString = replace(@XMLString, '€', '&#128;') 

	set @XMLStringReturn = @XMLString

RETURN @XMLStringReturn
END




