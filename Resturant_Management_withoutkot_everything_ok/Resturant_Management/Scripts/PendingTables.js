
function GetThisElemntFromLocalStorage(RecieeptNo) {

    //alert("I am here" + RecieeptNo);
    var data = JSON.parse(localStorage.getItem(RecieeptNo));


    //GrandTotal = 0;
    $('#ServiceBoy,#TableNo,#TotalAmount,#OrderNo').val('');
    $('#orderdetailsItems tbody tr').remove();
    $('#Submit').attr('Value', 'Save Order');

    $('#OrderNo').val(data.RecieptNo);
    $('#ServiceBoy').val(data.ServiceBoyid);
    $('#TableNo').val(data.TableNo);
    $('#TotalAmount').val(data.NetAmount);
    $.each(data.OrderedItems, function (i, item) {

        var productItem = '<tr> <td class="ProductId">' + item.ProductId + '</td><td class="pc">' + item.ProductName + '</td><td class="Quantity">' + item.Quantity + '</td><td class="DiscountRate">' + item.DiscountRate + '</td><td class="Rate">' + item.UnitPrice + '</td><td class="TotalPrice">' + item.Total + '</td><td>' + '<input type="button" value="Remove" class="remove btn-danger form-control"/>' + '</td></tr>';
        $('#orderdetailsItems tbody').append(productItem);

    })
    $('#TotalAmount').val(data.NetAmount);

};