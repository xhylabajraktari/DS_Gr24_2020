function bcipher_encode() {
    var text = document.getElementById("bcipher_text_et").value;
    var book = document.getElementById("bcipher_text_eb").value;
    var book_array = book.split(' ');
    var temp = [];
    for(var i = 0;i < text.length; i++){
        var j = 0;
        while(j !== book_array.length) {
            if(book_array[j].charAt(0) === text[i]) {
                temp += j + 1 + ' ';
                break;
            }
            j++;
        }
    }
    document.getElementById('bcipher_encode').innerHTML = temp;
}

function bcipher_decode() {
    var text = document.getElementById("bcipher_text_dt").value;
    var book = document.getElementById("bcipher_text_db").value;
    var book_array = book.split(' ');
    var text_n = text.split(' ');
    var temp = [];//I JA OSHT TEXT DMTH NUMRAT
    for(var i = 0;i < text_n.length; i++){
        var x = parseInt(text_n[i]) - 1;
        temp += book_array[x].charAt(0);
    }
    document.getElementById('bcipher_decode').innerHTML = temp;
}
//A night before the movie theater allowed patrol to buy tickets early //as a way to reserve seats for a later showing.
//2,12,18,12,17