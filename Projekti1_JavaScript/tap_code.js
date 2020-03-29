function tap_encode() {
    var arg = document.getElementById("tap_code_e").value.toLowerCase();
    var temp = [];
    for(var i = 0; i < arg.length; i++ ) {
        temp += tap_encode_switch(arg[i]);
        temp += " ";
    }
    document.getElementById('tap_encode').innerHTML = temp;
}

function tap_decode() {
    var arg = document.getElementById("tap_code_d").value;
    var argArr = arg.split(/(\s+)/).filter( function(e) { return e.trim().length > 0; } ); // split by space
    var temp = [];
    for(var i = 1; i < arg.length; i+=2) {
        temp += tap_decode_switch((argArr[i - 1] + " " + argArr[i])); // read by two
    }
    document.getElementById('tap_decode').innerHTML = temp;
}
//Funksioni per me dekodu germat e alfabetit ne tap-code.
function tap_encode_switch(string){
    switch(string){
        case 'a':
            return'. .';
            break;
        case 'b':
            return'. ..';
            break;
        case 'c':
            return'. ...';
            break;
        case 'k':
            return'. ...';
            break;
        case 'd':
            return'. ....';
            break;
        case 'e':
            return'. .....';
            break;
        case 'f':
            return'.. .';
            break;
        case 'g':
            return'.. ..';
            break;
        case 'h':
            return'.. ...';
            break;
        case 'i':
            return'.. ....';
            break;
        case 'j':
            return'.. .....';
            break;
        case 'l':
            return'... .';
            break;
        case 'm':
            return'... ..';
            break;
        case 'n':
            return'... ...';
            break;
        case 'o':
            return'... ....';
            break;
        case 'p':
            return'... .....';
            break;
        case 'q':
            return'.... .';
            break;
        case 'r':
            return'.... ..';
            break;
        case 's':
            return'.... ...';
            break;
        case 't':
            return'.... ....';
            break;
        case 'u':
            return'.... .....';
            break;
        case 'v':
            return'..... .';
            break;
        case 'w':
            return'..... ..';
            break;
        case 'x':
            return'..... ...';
            break;
        case 'y':
            return'..... ....';
            break;
        case 'z':
            return'..... .....';
            break;
        case ' ':
            return '/ /';
            break;
        default:
            return '';
            break;

    }
}
//Funksioni per me dekodu germat e alfabetit ne tap-code.
function tap_decode_switch(text){
    switch(text){
        case '. .':
            return 'a';
            break;
        case '. ..':
            return 'b';
            break;
        case '. ...':
            return 'c';
            break;
        case '. ....':
            return 'd';
            break;
        case '. .....':
            return 'e';
            break;
        case '.. .':
            return 'f';
            break;
        case '.. ..':
            return 'g';
            break;
        case '.. ...':
            return 'h';
            break;
        case '.. ....':
            return 'i';
            break;
        case '.. .....':
            return 'j';
            break;
        case '... .':
            return 'l';
            break;
        case '... ..':
            return 'm';
            break;
        case '... ...':
            return 'n';
            break;
        case '... ....':
            return 'o';
            break;
        case '... .....':
            return 'p';
            break;
        case '.... .':
            return 'q';
            break;
        case '.... ..':
            return 'r';
            break;
        case '.... ...':
            return 's';
            break;
        case '.... ....':
            return 't';
            break;
        case '.... .....':
            return 'u';
            break;
        case '..... .':
            return 'v';
            break;
        case '..... ..':
            return 'w';
            break;
        case '..... ...':
            return 'x';
            break;
        case '..... ....':
            return 'y';
            break;
        case '..... .....':
            return 'z';
            break;
        case '/ /':
            return ' ';
            break;
        default:
            return '';
            break;
    }
}