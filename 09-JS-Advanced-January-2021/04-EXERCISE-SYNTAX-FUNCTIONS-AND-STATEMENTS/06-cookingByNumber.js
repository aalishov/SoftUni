function cooking(num, s1, s2, s3, s4, s5) {
    let number = +num;
    let array = [s1, s2, s3, s4, s5];

    function cook(number, cmd) {

    }
    let result = "";
    for (let i = 0; i < array.length; i++) {
        switch (array[i]) {
            case "chop":
                number /= 2;
                break;
            case "dice":
                number = Math.sqrt(number);
                break;
            case "spice":
                number++;
                break;
            case "bake":
                number *= 3
                break;
            case "fillet":
                number -= (number * 20 / 100);
                break;
        }
        result += number + "\n";
    }
    return result;
}

console.log(cooking('32', 'chop', 'chop', 'chop', 'chop', 'chop'));
console.log(cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet'));