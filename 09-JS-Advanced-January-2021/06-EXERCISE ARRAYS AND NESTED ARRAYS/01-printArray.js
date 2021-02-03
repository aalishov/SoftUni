function solve(array, delimiter) {
    let result = '';

    for (let i = 0; i < array.length; i++) {
        result += i == array.length-1 ? array[i] : array[i] + delimiter;
    }

    return result;
}

console.log(solve(['One',
    'Two',
    'Three',
    'Four',
    'Five'],
    '-'
));

console.log(solve['How about no?',
    'I',
    'will',
    'not',
    'do',
    'it!'],
    '_'
);