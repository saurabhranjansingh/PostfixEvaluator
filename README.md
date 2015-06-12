# Evaluating any postfix expression in C# .NET

Reverse Polish notation (RPN) or <b>Postfix Notation</b> is a mathematical notation in which every operator follows all of its operands and is normally parenthesis-free. eg - 5 1 2 + 4 * + 3 -

The algorithm for evaluating a postfix expression goes like this:
(Source: http://en.wikipedia.org/wiki/Reverse_Polish_notation)

<ul>
<li>While there are input tokens left
<ul>
<li>Read the next token from input.</li>
<li>If the token is a value
<ul>
<li>Push it onto the stack.</li>
</ul>
</li>
<li>Otherwise, the token is an operator (operator here includes both operators and functions).
<ul>
<li>It is known a priori that the operator takes <b>n</b> arguments.</li>
<li>If there are fewer than <b>n</b> values on the stack
<ul>
<li><b>(Error)</b> The user has not input sufficient values in the expression.</li>
</ul>
</li>
<li>Else, Pop the top <b>n</b> values from the stack.</li>
<li>Evaluate the operator, with the values as arguments.</li>
<li>Push the returned results, if any, back onto the stack.</li>
</ul>
</li>
</ul>
</li>
<li>If there is only one value in the stack
<ul>
<li>That value is the result of the calculation.</li>
</ul>
</li>
<li>Otherwise, there are more values in the stack
<ul>
<li><b>(Error)</b> The user input has too many values.</li>
</ul>
</li>
</ul>
