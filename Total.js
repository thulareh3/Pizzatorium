var total = 0;

function test(item)
{
    if (item.checked)
    {
        total += parseInt(item.value);
    }
    else
    {
        if (total != 0)
        {
            total -= parseInt(item.value);
        }
        else
        {
            total = 0;
        }
    }
    //alert(total);
    document.getElementById("Totalcost").innerHTML = "R " + total;
}