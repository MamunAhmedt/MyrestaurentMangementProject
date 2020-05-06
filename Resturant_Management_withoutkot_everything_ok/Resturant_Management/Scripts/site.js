var GrandTotal = 0;
var list;
var PurchaseDate;
var data;
function CalculateNetAmountforPuchasedItem() {

	$('#PurchaseGrandAmount').val("");

	var quantity = parseInt($('#Quantity').val());

	if (quantity == 0 ) {
		$('#Quantity').siblings('span.error').css('visibility', 'visible');
	}
	

	var unitprice = parseInt($('#PurchaseUnitPrice').val());

	
	$('#PurchaseGrandAmount').val(quantity * unitprice);

}


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
	 PurchaseDate = month + "/" + day + "/" + year + "/";

}
$(document).ready(function() {
    

	$('#AddPurchaseditem').click(function () {

        var isAllValid = true;

		var checkDate = CheckDate();

		if (!checkDate) {
			isAllValid = false;
		}



		

		

		if ($('#ItemName').val() == "") {
			isAllValid = false;
			$('#ItemName').siblings('span.error').css('visibility', 'visible');
		}
		else {
			$('#ItemName').siblings('span.error').css('visibility', 'hidden');
		}

		if (($('#Category').val()) == "") {
			isAllValid = false;
			$('#Category').siblings('span.error').css('visibility', 'visible');
		}
		else {
			$('#Category').siblings('span.error').css('visibility', 'hidden');
		}


		if (!($('#Quantity').val().trim() != '' && (parseInt($('#Quantity').val()) || 0))) {
			isAllValid = false;
			$('#Quantity').siblings('span.error').css('visibility', 'visible');
		}
		else {
			$('#Quantity').siblings('span.error').css('visibility', 'hidden');
		}





		if (!($('#Unit').val().trim() != '' && (parseInt($('#Unit').val()) || 0))) {
			isAllValid = false;
			$('#Unit').siblings('span.error').css('visibility', 'visible');
		}
		else {
			$('#Unit').siblings('span.error').css('visibility', 'hidden');
		}

		if (!($('#PurchaseUnitPrice').val().trim() != '' && (parseInt($('#PurchaseUnitPrice').val()) || 0))) {
			isAllValid = false;
			$('#PurchaseUnitPrice').siblings('span.error').css('visibility', 'visible');
		}
		else {
			$('#PurchaseUnitPrice').siblings('span.error').css('visibility', 'hidden');
		}


		if (isAllValid) {
			var
				category = ($('#Category option:selected').text()),
				ProductName = $('#ItemName').val(),
				Quantity = parseInt($('#Quantity').val()),
				Unit = $('#Unit option:selected').text(),
				UnitPrice = parseInt($('#PurchaseUnitPrice').val()),
				Total = parseInt($('#PurchaseGrandAmount').val());
			    GrandTotal = GrandTotal + Total;
			// addbution = $('#Add').clone().removeAttr('id'),
			// addbution = addbution.addClass('remove').val('remove').removeClass('btn-success').addClass('btn-danger');


			var productItem = '<tr><td class="Name">' +
				ProductName +
				'</td><td class="Category">' +
				category +
				'</td><td class="Quantity">' +
				Quantity +
				'</td><td class="Unit">' +
				Unit +
				'</td><td class="UnitPrice">' +
				UnitPrice +
				'</td><td class="Total"> ' +
				Total +
				'</td><td>' +
				'<input type="button" value="Remove" class="remove btn-danger form-control"/>' +
				'</td></tr>';

			$('#ExpenseItemList tbody').append(productItem);
			$('#TotalAmount').val(GrandTotal);

			$('#Category,#Unit').val('1');
			$('#Quantity,#PurchaseUnitPrice,#PurchaseGrandAmount,#ItemName').val('');
			/*
			$('#orderItemError').empty();
			*/
		}
	});

	$('#ExpenseItemList').on('click', '.remove', function () {
		RemoveItemTotal = parseInt($(this).closest("tr").find('td:eq(5)').text());
		GrandTotal = (GrandTotal - RemoveItemTotal);
		RemoveItemTotal=0;
		$(this).parents('tr').remove();
		$('#TotalAmount').val(GrandTotal);
		


	});

	$('#Submit').click(function () {
        list = [];
        var isallvalid = true;
		GetFormatedDate();
		$('#ExpenseItemList tbody tr').each(function (index, ele) {

			var ExpenseItem = {
				Purchasedate:PurchaseDate,
				Name: $('.Name', this).text(),
				Category: $('.Category', this).text(),
				Quantity: parseInt($('.Quantity', this).text()),
				Units: $('.Unit', this).text(),
				UnitPrice: parseFloat($('.UnitPrice', this).text()),
				NetAmount: parseFloat($('.Total', this).text()),
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
                url: '/Purchase/save',
                data: JSON.stringify(list),
                contentType: 'application/json',
                success: function(data) {
                    if (data.status) {
                        alert('Successfully saved');
                        //here we will clear the form
                        GrandTotal = 0;
                        $('#Category,#Unit,#TotalAmount').val('0');
                        $('#Quantity,#PurchaseUnitPrice,#ItemName,#date').val('');
                        $('#ExpenseItemList tbody tr').remove();
                        $('#Submit').attr('Value', 'Save Order');
                        
                    } else {
                        alert('Error');
                    }


                },
                error: function(error) {
                    console.log(error);
                    $('#Submit').text('Save');
                }
            });
        }
    });

   


});
