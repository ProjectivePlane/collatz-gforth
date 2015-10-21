: collatz-func ( n -- n)
    dup 2 mod
    0= if
	2 /
    else
	3 * 1 +
    then ;

: print-collatz-sequence
    begin
	dup . cr dup 1 > while
	    collatz-func
	repeat ;