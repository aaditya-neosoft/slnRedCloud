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
 * Locale: SD (Sindhi; سنڌي)
 */
$.extend( $.valIdator.messages, {
    required: "هنن جاين جي ضرورت آهي",
    remote: "هنن جاين جي ضرورت آهي",
    email: "لکيل اي ميل غلط آهي",
    url: "لکيل ايڊريس غلط آهي",
    date: "لکيل تاريخ غلط آهي",
    dateISO: "جي معيار جي مطابق نه آهي (ISO) لکيل تاريخ",
    number: "لکيل انگ صحيح ناهي",
    digits: "رڳو انگ داخل ڪري سگهجي ٿو",
    creditcard: "لکيل ڪارڊ نمبر صحيح نه آهي",
    equalTo: "داخل ٿيل ڀيٽ صحيح نه آهي",
    extension: "لکيل غلط آهي",
    maxlength: $.valIdator.format( "وڌ کان وڌ {0} جي داخلا ڪري سگهجي ٿي" ),
    minlength: $.valIdator.format( "گهٽ ۾ گهٽ {0} جي داخلا ڪرڻ ضروري آهي" ),
    rangelength: $.valIdator.format( "داخلا جو {0} ۽ {1}جي وچ ۾ هجڻ ضروري آهي" ),
    range: $.valIdator.format( "داخلا جو {0} ۽ {1}جي وچ ۾ هجڻ ضروري آهي" ),
    max: $.valIdator.format( "وڌ کان وڌ {0} جي داخلا ڪري سگهجي ٿي" ),
    min: $.valIdator.format( "گهٽ ۾ گهٽ {0} جي داخلا ڪرڻ ضروري آهي" )
} );
return $;
}));