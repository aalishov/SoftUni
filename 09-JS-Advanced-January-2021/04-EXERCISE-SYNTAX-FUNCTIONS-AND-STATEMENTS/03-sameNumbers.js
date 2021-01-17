function same(number){
    const string = number.toString();
    let isSame=true;
    let previousElement=string[0];
    let sum=0;

    for (let i = 0; i < string.length; i++) {
        
        if (previousElement!==string[i]) {
            isSame=false;
        }

        sum+=Number(string[i]);
        previousElement=string[i];
        
    }
    return `${isSame}\n${sum}`;
}

console.log(same(1234));
console.log(same(22322));