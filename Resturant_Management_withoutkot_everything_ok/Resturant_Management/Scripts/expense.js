var GrandTotal = 0;
var list;
var ExpenseDate;
var data;



function CheckDate() {


	var showingdate = new Date($('#date').val());

	var status = true;


	var day = (showingdate.getDate());
	var month = (showingdate.getMonth() + 1);

	var year = (showingdate.getFullYear());


	if (day.toString() == "NaN" || month.toString() == "NaN" || year.toString() == "NaN") {
		$('#DateError').css('visibility', 'visible').html("Please select Valid Date");
		status = false;
		return status;

	}

	else {

		$('#DateError').css('visibility', 'hidden');


	}
	return status;

}

function GetFormatedDate() {

	var date = new Date($('#date').val());
	day = (date.getDate());
	month = (date.getMonth() + 1);

	year = (date.getFullYear());

	if (day.toString().length == 1) {
		day = "0" + day;
	}
	if (month.toString().length == 1) {
		month = "0" + month;
	}

	// alert(day.toString().length);
	ExpenseDate = month + "/" + day + "/" + year + "/";

}
$(document).ready(function () {


	$('#AddPurchaseditem').click(function () {

		var isAllValid = true;

		var checkDate = CheckDate();

		if (!checkDate) {
			isAllValid = false;
		}



		if (($('#Category').val()) == "") {
			isAllValid = false;
			$('#Category').siblings('span.error').css('visibility', 'visible');
		}
		else {
			$('#Category').siblings('span.error').css('visibility', 'hidden');
		}


		if (!($('#Amount').val().trim() != '' && (parseInt($('#Amount').val()) || 0))) {
			isAllValid = false;
			$('#Amount').siblings('span.error').css('visibility', 'visible');
		}
		else {
			$('#Amount').siblings('span.error').css('visibility', 'hidden');
		}


		if ($('#Description').val() == "") {
			isAllValid = false;
			$('#Description').siblings('span.error').css('visibility', 'visible');
		}
		else {
			$('#Description').siblings('span.error').css('visibility', 'hidden');
		}




		if (isAllValid) {
			var
				category = ($('#Category option:selected').text()),
				Amount = parseInt($('#Amount').val()),
				Description=$('#Description').val(),
				Total =parseInt($('#Amount').val());
				 GrandTotal = GrandTotal + Total;
			// addbution = $('#Add').clone().removeAttr('id'),
			// addbution = addbution.addClass('remove').val('remove').removeClass('btn-success').addClass('btn-danger');


			var productItem = '<tr><td class="Category">' +
				category +
				'</td><td class="Amount">' +
				Amount +
				'</td><td class="Description">' +
				Description +
				'</td><td>' +
				'<input type="button" value="Remove" class="remove btn-danger form-control"/>' +
				'</td></tr>';

			$('#ExpenseItemList tbody').append(productItem);
			$('#TotalAmount').val(GrandTotal);

			$('#Category').val('1');
			$('#Amount,#Description').val('');
			/*
			$('#orderItemError').empty();
			*/
		}
	});

	$('#ExpenseItemList').on('click', '.remove', function () {
		RemoveItemTotal = parseInt($(this).closest("tr").find('td:eq(5)').text());
		GrandTotal = (GrandTotal - RemoveItemTotal);
		RemoveItemTotal = 0;
		$(this).parents('tr').remove();
		$('#TotalAmount').val(GrandTotal);



	});

	$('#Submit').click(function () {
		list = [];
		var isallvalid = true;
		GetFormatedDate();
		$('#ExpenseItemList tbody tr').each(function (index, ele) {

			var ExpenseItem = {
				
				Category: $('.Category', this).text(),
				Amount: parseInt($('.Amount', this).text()),
				Date: ExpenseDate,
				Description: $('.Description', this).text(),
				
				GrandTotal: 0

			}
			list.push(ExpenseItem);


		});

		if (list.length == 0) {
			isallvalid = false;
			$('#orderItemError').html('At least 1 order item required.').css('visibility', 'visible');


		}


		if (isallvalid) {


			$(this).val('Please wait...');


			$.ajax({
				type: 'POST',
				url: '/Expense/save',
				data: JSON.stringify(list),
				contentType: 'application/json',
				success: function (data) {
					if (data.status) {
						alert('Successfully saved');
						//here we will clear the form
						GrandTotal = 0;
						$('#Category').val('1');
						$('#Amount,#Description,#date,#TotalAmount').val('');
						$('#ExpenseItemList tbody tr').remove();
						
						$('#Submit').attr('Value', 'Save Order');

					}

					else {
						alert('Error');
					}


				},
				error: function (error) {
					console.log(error);
					$('#Submit').text('Save');
				}
			});
		}
	});




});
