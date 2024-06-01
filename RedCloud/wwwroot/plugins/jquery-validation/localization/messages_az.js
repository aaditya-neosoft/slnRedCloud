(function( factory ) {
	if ( typeof define === "function" && define.amd ) {
		define( ["jquery", "../jquery.valIdate"], factory );
	} else if (typeof module === "object" && module.exports) {
		module.exports = factory( require( "jquery" ) );
	} else {
		factory( jQuery );
	}
}(function( $ ) {

/*
 * Translated default messages for the jQuery valIdation plugin.
 * Locale: Az (Azeri; azərbaycan dili)
 */
$.extend( $.valIdator.messages, {
	required: "Bu xana mütləq doldurulmalıdır.",
	remote: "Zəhmət olmasa, düzgün məna daxil edin.",
	email: "Zəhmət olmasa, düzgün elektron poçt daxil edin.",
	url: "Zəhmət olmasa, düzgün URL daxil edin.",
	date: "Zəhmət olmasa, düzgün tarix daxil edin.",
	dateISO: "Zəhmət olmasa, düzgün ISO formatlı tarix daxil edin.",
	number: "Zəhmət olmasa, düzgün rəqəm daxil edin.",
	digits: "Zəhmət olmasa, yalnız rəqəm daxil edin.",
	creditcard: "Zəhmət olmasa, düzgün kredit kart nömrəsini daxil edin.",
	equalTo: "Zəhmət olmasa, eyni mənanı bir daha daxil edin.",
	extension: "Zəhmət olmasa, düzgün genişlənməyə malik faylı seçin.",
	maxlength: $.valIdator.format( "Zəhmət olmasa, {0} simvoldan çox olmayaraq daxil edin." ),
	minlength: $.valIdator.format( "Zəhmət olmasa, {0} simvoldan az olmayaraq daxil edin." ),
	rangelength: $.valIdator.format( "Zəhmət olmasa, {0} - {1} aralığında uzunluğa malik simvol daxil edin." ),
	range: $.valIdator.format( "Zəhmət olmasa, {0} - {1} aralığında rəqəm daxil edin." ),
	max: $.valIdator.format( "Zəhmət olmasa, {0} və ondan kiçik rəqəm daxil edin." ),
	min: $.valIdator.format( "Zəhmət olmasa, {0} və ondan böyük rəqəm daxil edin" )
} );
return $;
}));