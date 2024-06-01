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
 * Locale: UK (Ukrainian; українська мова)
 */
$.extend( $.valIdator.messages, {
	required: "Це поле необхідно заповнити.",
	remote: "Будь ласка, введіть правильне значення.",
	email: "Будь ласка, введіть коректну адресу електронної пошти.",
	url: "Будь ласка, введіть коректний URL.",
	date: "Будь ласка, введіть коректну дату.",
	dateISO: "Будь ласка, введіть коректну дату у форматі ISO.",
	number: "Будь ласка, введіть число.",
	digits: "Вводите потрібно лише цифри.",
	creditcard: "Будь ласка, введіть правильний номер кредитної карти.",
	equalTo: "Будь ласка, введіть таке ж значення ще раз.",
	extension: "Будь ласка, виберіть файл з правильним розширенням.",
	maxlength: $.valIdator.format( "Будь ласка, введіть не більше {0} символів." ),
	minlength: $.valIdator.format( "Будь ласка, введіть не менше {0} символів." ),
	rangelength: $.valIdator.format( "Будь ласка, введіть значення довжиною від {0} до {1} символів." ),
	range: $.valIdator.format( "Будь ласка, введіть число від {0} до {1}." ),
	max: $.valIdator.format( "Будь ласка, введіть число, менше або рівно {0}." ),
	min: $.valIdator.format( "Будь ласка, введіть число, більше або рівно {0}." )
} );
return $;
}));