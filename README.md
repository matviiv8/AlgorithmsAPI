# AlgorithmsAPI

This is an API that provides access to various algorithms for sorting, searching, encryption, mathematical operations, and string operations. You can use this API to implement various algorithmic functions in your projects.

## Usage

To use this API, make requests to the following URLs:

| Algorithm | Description | Example URL |
| --- | --- | --- |
| **Sort Algorithms** | | |
| Bubble Sort | Sorts an array using the bubble sort algorithm. | `https://{{baseUrl}}/sort/bubble` |
| Quick Sort | Sorts an array using the quick sort algorithm. | `https://{{baseUrl}}/sort/quick` |
| Selection Sort | Sorts an array using the selection sort algorithm. | `https://{{baseUrl}}/sort/selection` |
| Insertion Sort | Sorts an array using the insertion sort algorithm. | `https://{{baseUrl}}/sort/insertion` |
| Cycle Sort | Sorts an array using the cycle sort algorithm. | `https://{{baseUrl}}/sort/cycle` |
| Counting Sort | Sorts an array using the counting sort algorithm. | `https://{{baseUrl}}/sort/counting` |
| Comb Sort | Sorts an array using the comb sort algorithm. | `https://{{baseUrl}}/sort/comb` |
| Shell Sort | Sorts an array using the shell sort algorithm. | `https://{{baseUrl}}/sort/shell` |
| Heap Sort | Sorts an array using the heap sort algorithm. | `https://{{baseUrl}}/sort/heap` |
| Merge Sort | Sorts an array using the merge sort algorithm. | `https://{{baseUrl}}/sort/merge` |
| **Search Algorithms** | | |
| Binary Search | Performs binary search on an ordered array. | `https://{{baseUrl}}/search/binary` |
| Linear Search | Performs linear search on an array. | `https://{{baseUrl}}/search/linear` |
| Interpolation Search | Performs interpolation search on a sorted array. | `https://{{baseUrl}}/search/interpolation` |
| Ternary Search | Performs ternary search on a sorted array. | `https://{{baseUrl}}/search/ternary` |
| Fibonacci Search | Performs Fibonacci search on a sorted array. | `https://{{baseUrl}}/search/fibonacci` |
| Sentinel Search | Performs sentinel search on an array. | `https://{{baseUrl}}/search/sentinel` |
| Jump Search | Performs jump search on a sorted array. | `https://{{baseUrl}}/search/jump` |
| **Cipher Algorithms** | | |
| Caesar Cipher | Applies the Caesar cipher to encrypt or decrypt a message. | `https://{{baseUrl}}/cipher/caesar` |
| Vigenere Cipher | Applies the Vigenere cipher to encrypt or decrypt a message. | `https://{{baseUrl}}/cipher/vigenere` |
| Scytale Cipher | Applies the Scytale cipher to encrypt or decrypt a message. | `https://{{baseUrl}}/cipher/scytale` |
| Atbash Cipher | Applies the Atbash cipher to encrypt or decrypt a message. | `https://{{baseUrl}}/cipher/atbash` |
| Rot13 Cipher | Applies the Rot13 cipher to encrypt or decrypt a message. | `https://{{baseUrl}}/cipher/rot13` |
| A1Z26 Cipher | Applies the A1Z26 cipher to encrypt or decrypt a message. | `https://{{baseUrl}}/cipher/a1z26` |
| **Mathematical Operations** | | |
| Factorial | Computes the factorial of a number. | `https://{{baseUrl}}/math/factorial` |
| Fibonacci | Generates the Fibonacci sequence up to a given number. | `https://{{baseUrl}}/math/fibonacci` |
| Iterative GCD | Computes the greatest common divisor (GCD) of two numbers iteratively. | `https://{{baseUrl}}/math/gcd/iterativeGCD` |
| Recursive GCD | Computes the greatest common divisor (GCD) of two numbers recursively. | `https://{{baseUrl}}/math/gcd/recursiveGCD` |
| Is Prime | Checks if a number is prime. | `https://{{baseUrl}}/math/isprime` |
| Sieve Of Eratosthenes | Finds all prime numbers up to a given number using the Sieve of Eratosthenes algorithm. | `https://{{baseUrl}}/math/sieveoferatosthenes` |
| **String Operations** | | |
| Is Palindrome | Checks if a string is a palindrome. | `https://{{baseUrl}}/strings/ispalindrom` |
| Unique Permutation | Generates all unique permutations of a string. | `https://{{baseUrl}}/strings/uniquepermutation` |
| Find Substring | Finds the first occurrence of a substring in a string. | `https://{{baseUrl}}/strings/findsubstring` |
| Reverse | Reverses a string. | `https://{{baseUrl}}/strings/reverse` |
| Replace Substring | Replaces all occurrences of a substring in a string. | `https://{{baseUrl}}/strings/replacesubstring` |

Replace `{{baseUrl}}` with the base URL of your API.

## Examples

Here are some examples of how to use the API:

- Sort an array using bubble sort:
  - Request: `POST https://{{baseUrl}}/sort/bubble`
  - Request body: `{ "5 2 8 1 9" }`

- Check if a string is a palindrome:
  - Request: `POST https://{{baseUrl}}/strings/ispalindrom?text=wow`

- Compute the factorial of a number:
  - Request: `POST https://{{baseUrl}}/math/factorial?number=3`

- Perform binary search on an array:
  - Request: `POST https://{{baseUrl}}/search/binary?item=3`
  - Request body: `{ "4 5 3 2 1 5" }`

- Apply the Caesar cipher to encrypt a message:
  - Request: `POST https://{{baseUrl}}/caesar?text=Hello&key=3&mode=Encrypt`

Feel free to add more algorithms and endpoints based on your requirements.
