: collatz-func ( n -- n)
    dup 2 mod
    0= if
	2 /
    else
	3 * 1 +
    then ;

: print-collatz-sequence ( n --)
    begin
	dup . cr dup 1 > while
	    collatz-func
    repeat
    drop ;

: collatz-sequence-length ( n -- n)
    dup 1 > if
	collatz-func recurse 1+
    then ;
    