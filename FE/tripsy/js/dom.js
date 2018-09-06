/* Super light, home-made thingy for jQuery-like DOM manipulations */

function $(s) {return new vDom(s)}

var vDom = function(s) {
	this.items = [];
	if (typeof(s) == "string") {
		this.items = (document).querySelectorAll(s);
	} else if (typeof(s) == "object") {		
		if (s instanceof NodeList) {this.items = s} else {this.items[0] = s}		
	}
	return this;
}

vDom.prototype = {
	/* CORE */	
	each : function(func) {return [].forEach.call(this.items, func)},	
	insert : function(where, what) {return this.each(function(el) {el.insertAdjacentHTML(where, what)})},	
	remove : function() {return this.each(function(el) {el.parentNode.removeChild(el)})},
	
	/* UNCHAINED */	
	toArray : function() {var arr = []; for(var i = this.items.length; i--; arr.unshift(this.items[i])); return arr},	
	hasClass : function(cname) {var foundClass = false; this.each(function(el) {if (el.classList.contains(cname)) {foundClass = true}}); return foundClass},
	
	/* Class change detection */
	detectClass : function(cname, fx_true, fx_false) {				
		var mutationObserver = new MutationObserver(function(mutations) {
			mutations.forEach(function(mutation) {if (mutation.type == 'attributes') {if (mutation.attributeName == "class") (mutation.target.classList.contains(cname)) ? fx_true() : fx_false();}	});
		});		
		return this.each(function(el) {mutationObserver.observe(el, {attributes: true}) })
	},
	
	/* CHAINED */
	before : function(htm) {this.insert('beforebegin', htm); return this},	
	after : function(htm) {this.insert('afterend', htm); return this},	
	prepend : function(htm) {this.insert('afterbegin', htm); return this},	
	append : function(htm) {this.insert('beforeend', htm); return this},
	html : function(htm) {this.items[0].innerHTML = htm; return this},
	bind : function(action, func) {this.each(function(el) {el.addEventListener(action, func)}); return this},	
	removeClass : function(cname) {this.each(function(el) {if (el.classList.contains(cname)) {el.classList.remove(cname)} }); return this},	
	addClass : function(cname) {this.each(function(el) {if (!el.classList.contains(cname)) {el.classList.add(cname)} }); return this},
	hide : function() {this.each(function(el) {el.style.display = "none"}); return this},	
	show : function() {this.each(function(el) {el.style.display = ""}); return this},
	attr : function(name, value) {if (typeof value === 'undefined') { return this.items[0].getAttribute(name) } else { this.each(function(el) {	el.setAttribute(name, value) }); return this} },
	removeAttr : function(name) {this.each(function(el) {el.removeAttribute(name)}); return this},
	trigger : function(event) {this.each(function(el) {el.dispatchEvent(new Event(event))}); return this},
	
	// TRAVERSING - RETURNING NEW OBJECT
	focus : function() {return $(this.items[0].focus())},
	blur : function() {return $(this.items[0].blur())},
	parent : function() {return $(this.items[0].parentNode)},
	closest : function(s) {var e = false; var el = this.items[0]; for ( ; el && el !== document; el = el.parentNode ) {if (el.matches(s)) {e = el}	}; if (e) return $(e)},
	find : function(s) {return $(this.items[0].querySelectorAll(s))}
}