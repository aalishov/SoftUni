const describe = require('mocha').describe;
const assert = require('chai').assert;

describe('charLookup', () => {
    it('', () => {
        assert.equal(numberOperations.powNumber(5),25);
        assert.equal(numberOperations.powNumber(-5),25);
        assert.equal(numberOperations.powNumber(0),0);
    });
    it('', () => {
        assert.throw(() => numberOperations.numberChecker('aa'), 'The input is not a number!');
        assert.throw(() => numberOperations.numberChecker('a'), 'The input is not a number!');
        assert.equal(numberOperations.numberChecker(55),'The number is lower than 100!')
        assert.equal(numberOperations.numberChecker([]),'The number is lower than 100!')
        assert.equal(numberOperations.numberChecker(100),'The number is greater or equal to 100!')
        assert.equal(numberOperations.numberChecker(150),'The number is greater or equal to 100!')
    });
    it('', () => {
        assert.deepEqual(numberOperations.sumArrays([5,2],[5,2]),[10,4]);
        assert.deepEqual(numberOperations.sumArrays([-5,2],[5,2]),[0,4]);
        assert.deepEqual(numberOperations.sumArrays([0],[0]),[0]);
        assert.deepEqual(numberOperations.sumArrays([0,3],[0]),[0,3]);
        assert.deepEqual(numberOperations.sumArrays([0],[0,3]),[0,3]);
    });
})


const numberOperations = {
    powNumber: function (num) {
        return num * num;
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input < 100) {
            return 'The number is lower than 100!';
        } else {
            return 'The number is greater or equal to 100!';
        }
    },
    sumArrays: function (array1, array2) {

        const longerArr = array1.length > array2.length ? array1 : array2;
        const rounds = array1.length < array2.length ? array1.length : array2.length;

        const resultArr = [];

        for (let i = 0; i < rounds; i++) {
            resultArr.push(array1[i] + array2[i]);
        }

        resultArr.push(...longerArr.slice(rounds));

        return resultArr
    }
};
