const describe = require('mocha').describe;
const assert = require('chai').assert;

describe('charLookup', () => {
    it('', () => {
        assert.isUndefined(lookupChar(1,1));
        assert.isUndefined(lookupChar('abc',1.2));
        assert.isUndefined(lookupChar('abc','a'));
    });

    it('', () => {
        assert.equal(lookupChar('abc',-1),"Incorrect index");
        assert.equal(lookupChar('abc',4),"Incorrect index");
    });
    
    it('', () => {
        assert.equal(lookupChar('abc',0),"a");
        assert.equal(lookupChar('abc',2),"c");
    });
})

function lookupChar(string, index) {
    if (typeof (string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

