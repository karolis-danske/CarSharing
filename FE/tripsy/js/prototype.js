// Document ready
document.addEventListener('DOMContentLoaded', function() {

	$("[prototype-action='open-modal']").bind("click", function(e) {
		initModal($(this));
		e.preventDefault();
	});
	
	$(".time-select .item").bind("click", function(e) {
		$(".time-select .item").removeClass("active");
		$(this).addClass("active");
		
	});
	
	$(".list.drivers li").bind("click", function(e) {
		window.location = "driver-details.html"
	});
})


/***************************
	MODAL
****************************/

function initModal(el) {
	$('#currentModal').remove(); // Just in case...
	
	var modalClass = el.attr('prototype-modal-class') ? el.attr('prototype-modal-class') : "";
	var modalHeader = el.attr('prototype-modal-header') ? el.attr('prototype-modal-header') : "";
	var modalBody = el.attr('prototype-modal-body') ? el.attr('prototype-modal-body') : "";
	
	if (modalHeader != "") {
		var Modal = "<div class=\"modal fade " + modalClass + "\" id=\"currentModal\"><div class=\"modal-dialog\"><div class=\"modal-header\">" + modalHeader + "</div><div class=\"modal-body\">" + modalBody + "</div></div></div>";
	
	} else {
		var Modal = "<div class=\"modal fade " + modalClass + "\" id=\"currentModal\"><div class=\"modal-dialog\"><div class=\"modal-body\" style=\"border-top-left-radius: 10px; border-top-right-radius: 10px \">" + modalBody + "</div></div></div>";
	
	}

	$('#wrapper').append(Modal);
	$('body').addClass('modal-open');
	
	setTimeout(function(){ 
		$("#currentModal").addClass('in').find('[prototype-action="close-modal"]').bind("click", function(e) {
			$("#currentModal").removeClass('in');
			$('body').removeClass('modal-open');
			setTimeout(function(){ 
				$("#currentModal").remove();
			}, 300);
		});
	}, 0);
}