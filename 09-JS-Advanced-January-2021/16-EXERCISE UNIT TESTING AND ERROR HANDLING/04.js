const describe = require('mocha').describe;
const assert = require('chai').assert;

describe('charLookup', () => {
    it('', () => {
        assert.isUndefined(mathEnforcer.addFive('a'));
        assert.isNaN(mathEnforcer.addFive(NaN));
    });
    it('',()=>{
        assert.equal(mathEnforcer.addFive(0),5);
        assert.equal(mathEnforcer.addFive(-5),0);
        assert.equal(mathEnforcer.addFive(1.2),6.2);
        assert.equal(mathEnforcer.addFive(1),6);
    });
    it('', () => {
        assert.isUndefined(mathEnforcer.subtractTen('a'));
        assert.isNaN(mathEnforcer.subtractTen(NaN));
    });
    it('',()=>{
        assert.equal(mathEnforcer.subtractTen(0),-10);
        assert.equal(mathEnforcer.subtractTen(-5),-15);
        assert.equal(mathEnforcer.subtractTen(5),-5);
        assert.equal(mathEnforcer.subtractTen(1.2),-8.8);
    });
    it('', () => {
        assert.isUndefined(mathEnforcer.sum('a','b'));
        assert.isUndefined(mathEnforcer.sum(1,'b'));
        assert.isUndefined(mathEnforcer.sum('a',1));
        assert.isNaN(mathEnforcer.sum(NaN,10));
    });
    it('',()=>{
        assert.equal(mathEnforcer.sum(0,5),5);
        assert.equal(mathEnforcer.sum(-1,-1),-2);
        assert.equal(mathEnforcer.sum(5,-20),-15);
        assert.equal(mathEnforcer.sum(5,-10),-5);
        assert.equal(mathEnforcer.sum(1.2,1.2),2.4);
    });
})

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

