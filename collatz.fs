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

: print-collatz-sequence-lengths-table ( n --)
    dup 1 > if
	1 ?do
	    i collatz-sequence-length i . ." " . cr
	loop
    else
	." Error: argument must be greater than 1."
    endif ;

: print-collatz-sequence-row ( n --)
    begin
	dup . ." " dup 1 > while
	    collatz-func
    repeat
    drop ;

: print-collatz-sequence-table ( n --)
    dup 1 > if
	1 ?do
	    i . ." " i print-collatz-sequence-row cr
	loop
    else
	." Error: argument must be greater than 1."
    endif ;

: collatz= ( n1 n2 - b)
    over collatz-sequence-length
    over collatz-sequence-length
    =
    swap drop swap drop ;

: collatz< ( n1 n2  - b)
    over collatz-sequence-length
    over collatz-sequence-length
    <
    swap drop swap drop ;

: collatz> ( n1 n2 - b)
    over collatz-sequence-length
    over collatz-sequence-length
    >
    swap drop swap drop ;
    
: collatz<= ( n1 n2 - b)
    over collatz-sequence-length
    over collatz-sequence-length
    <=
    swap drop swap drop ;

: collatz>= ( n1 n2 - b)
    over collatz-sequence-length
    over collatz-sequence-length
    >=
    swap drop swap drop ;

: collatz<> ( n1 n2 - b)
    over collatz-sequence-length
    over collatz-sequence-length
    <>
    swap drop swap drop ;

: collatz-length-diff ( n1 n2 - n3)
    over collatz-sequence-length
    over collatz-sequence-length
    - negate
    swap drop swap drop ;

: calc-even-predecessor ( n1 - n2)
    2 * ;

: has-odd-predecessor ( n1 - b)
    dup 1- 3 mod 0= swap drop ;

: calc-odd-predecessor ( n1 - n2)
    1- 3 / ;

: count-predecessors ( n1 --)
    has-odd-predecessor if
	2
    else
	1
    then ;

: calc-predecessors ( n1 -- n2 n3)
    dup count-predecessors 1 = if
	calc-even-predecessor
    else
	dup calc-even-predecessor swap calc-odd-predecessor
    then ;

: print-predecessors
    dup count-predecessors 1 = if
	calc-even-predecessor . cr
    else
	dup calc-even-predecessor swap calc-odd-predecessor . ." " . cr
    then ;

: is-power-of-two ( n -- b)
    dup 2 mod 0<> if
	drop false
    else
	begin
	    dup dup 2 mod 0= swap 1 > and while
		2 /
	repeat
	1 > if
	    false
	else
	    true
	then
    then ;

: transfer-two-factor ( n1 n2 -- n1/2 n2*2)
    2 * swap 2 / swap ;

: under-is-even ( n1 n2 -- n1 n2 b)
    over 2 mod 0= ;

: factor-out-power-of-two ( n -- n1 n2)
    dup is-power-of-two if
	1 swap
    else
	1
	begin
	    under-is-even while
		transfer-two-factor
	repeat
    then ;

: collatz-func-with-count ( n -- n)
    dup 2 mod
    0= if
	2 /
	>r swap 1+ swap r>
    else
	3 * 1 +
	>r 1+ r>
    then ;


: calculate-collatz-sequence-ups-downs ( n -- downs ups)
    0 0 rot
    begin
	dup 1 > while
	    collatz-func-with-count
    repeat
    drop ;

: calculate-collatz-sequence-ups-downs-diff ( n -- ndiff)
    calculate-collatz-sequence-ups-downs - ;

: print-ups-downs-table ( n --)
    1 ?do
	i calculate-collatz-sequence-ups-downs
	i . ." " swap . ." " . cr
    loop ;