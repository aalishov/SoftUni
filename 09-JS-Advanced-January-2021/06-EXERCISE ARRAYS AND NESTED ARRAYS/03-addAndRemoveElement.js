function solve(arr) {
    let counter = 1;
    let numbers = [];

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] === 'add') {
            numbers.push(counter);
        }
        else if (arr[i] === 'remove' & arr.length > 0) {
            numbers.pop();
        }
        counter++;
    }
    return numbers.length != 0 ? numbers.join('\n') : 'Empty';
}

console.log(solve(['add', 'add', 'add', 'add']));
console.log(solve(['add', 'add', 'remove', 'add', 'add']));