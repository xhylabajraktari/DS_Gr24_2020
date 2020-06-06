function rail_encode() {
    var arg = document.getElementById("rail_code_e").value.replace(/\s/g, '').toUpperCase(); // replace remove spaces
    var rails = document.getElementById("r_number").value;//document eshte objekti e value eshte vlera e objektit
    var temp = [];

    while(arg.length % rails !== 0) {
        arg += generate_random_string(1);
    }

    var col = arg.length / rails; // colonat
    var counter = 0; // counteri
    for(var i = 1;i <= rails; i++) { // colon
        for(var j = 0;j < col; j++) { // rreshti
            temp += arg[counter];
            counter += parseInt(rails);
        }
        counter = i; // kthe counterin barabart me I
    }
    document.getElementById('rail_encode').innerHTML = temp.replace(/(.{5})/g,"$1 "); // add spaces after 5 string
}

function rail_decode() {
    var arg = document.getElementById("rail_code_d").value.replace(/\s/g, '').toUpperCase();
    var rails = document.getElementById("r_number").value;
    var temp = [];
    var col = arg.length / rails;
    var counter = 0;

    for(var i = 1;i <= col; i++) {
        for(var j = 0;j < rails; j++) {
            temp += arg[counter];
            counter += parseInt(col);
        }
        counter = i;
    }

    document.getElementById('rail_decode').innerHTML = temp;
}


// STACKOVERFLOW
function generate_random_string(string_length){
    let random_string = '';
    let random_ascii;
    let ascii_low = 65;
    let ascii_high = 90;
    for(let i = 0; i < string_length; i++) {
        random_ascii = Math.floor((Math.random() * (ascii_high - ascii_low)) + ascii_low);
        random_string += String.fromCharCode(random_ascii)
    }
    return random_string;
}