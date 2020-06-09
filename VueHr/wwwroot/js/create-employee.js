$(document).ready(function () {

    // Random Alert shown for the fun of it
    function randomAlert() {
        var min = 5,
            max = 20;
        var rand = Math.floor(Math.random() * (max - min + 1) + min); //Generate Random number between 5 - 20
        // post time in a <span> tag in the Alert
        $("#time").html('Next alert in ' + rand + ' seconds');
        $('#timed-alert').fadeIn(500).delay(3000).fadeOut(500);
        setTimeout(randomAlert, rand * 1000);
    };
    randomAlert();
});

$('.next-prev').click(function (event) {
    event.preventDefault();
    var target = $(this).data('target');
    // console.log('#'+target);
    $('#click-alert').html('data-target= ' + target).fadeIn(50).delay(3000).fadeOut(1000);
});


// Multi-Step Form
var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the crurrent tab

function showTab(n) {
    // This function will display the specified tab of the form...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    //... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
        document.getElementById("nextBtn").style.display = "inline";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").style.display = "none";
        document.getElementById("submitBtn").style.display = "inline";
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
        document.getElementById("submitBtn").style.display = "none";
    }
    $("#prevBtn").click(function (e) {
        document.getElementById("nextBtn").style.display = "inline";
    })
    //... and run a function that will display the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:

    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form...
    if (currentTab >= x.length) {
        // ... the form gets submitted:
        document.getElementById("regForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class on the current step:
    x[n].className += " active";
}
$(function () {
    $("#btnAdd").click(function (e) {
        var itemIndex = $("#TextBoxContainer input.iHidden").length;
        console.log(itemIndex);
        var div = $("<tr />");
        div.html(GetDynamicTextBox(itemIndex));
        $("#TextBoxContainer").append(div);
    });

    $("body").on("click", ".remove", function () {
        console.log("Hello")
        $(this).closest("tr").remove();
    });
});
function GetDynamicTextBox(itemIndex) {
    return "<td><input type='text' class='form-control iHidden' id='EmployeeWorkBackground" + itemIndex + "__Company' name='EmployeeWorkBackground[" + itemIndex + "].Company'/></td><td><input type='text' class='form-control' id='EmployeeWorkBackground" + itemIndex + "__Position' name='EmployeeWorkBackground[" + itemIndex + "].Position'/></td><td><input type='date' class='form-control' id='EmployeeWorkBackground" + itemIndex + "__From' name='EmployeeWorkBackground[" + itemIndex + "].From'/></td><td><input type='date' class='form-control' id='EmployeeWorkBackground" + itemIndex + "__To' name='EmployeeWorkBackground[" + itemIndex + "].To'/></td><td><input type='text' class='form-control' id='EmployeeWorkBackground" + itemIndex + "__Reason' name='EmployeeWorkBackground[" + itemIndex + "].Reason'/></td><td><input type='text' class='form-control' id='EmployeeWorkBackground" + itemIndex + "__ContactNumber' name='EmployeeWorkBackground[" + itemIndex + "].ContactNumber'/></td><td><button type='button' class='btn btn-danger remove'><i class='glyphicon glyphicon-remove-'sign'></i></button></td>"
}

$(function () {
    $("#addReference").click(function (e) {
        var itemIndex = $("#referenceBoxContainer input.iHidden").length;
        console.log(itemIndex);
        var div = $("<tr />");
        div.html(GetReferenceTextBox(itemIndex));
        $("#referenceBoxContainer").append(div);
    });

    $("body").on("click", ".remove", function () {
        console.log("Hello")
        $(this).closest("tr").remove();
    });
});
function GetReferenceTextBox(itemIndex) {
    return "<td><input type='text' class='form-control iHidden' id='EmployeeReferences" + itemIndex + "__Name' name='EmployeeReferences[" + itemIndex + "].Name'/></td><td><input type='text' class='form-control' id='EmployeeReferences" + itemIndex + "__Company' name='EmployeeReferences[" + itemIndex + "].Company'/></td><td><input type='text' class='form-control' id='EmployeeReferences" + itemIndex + "__Position' name='EmployeeReferences[" + itemIndex + "].Position'/></td><td><input type='text' class='form-control' id='EmployeeReferences" + itemIndex + "__ContactNumber' name='EmployeeReferences[" + itemIndex + "].ContactNumber'/><td><button type='button' class='btn btn-danger remove'><i class='glyphicon glyphicon-remove-'sign'></i></button></td>"
}
