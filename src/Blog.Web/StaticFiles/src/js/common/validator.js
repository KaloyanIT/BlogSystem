/* eslint-disable no-useless-escape */
/* eslint-disable no-restricted-globals */
/* eslint-disable no-undef */
/* eslint-disable no-unused-vars */
/* eslint-disable no-plusplus */
/* eslint-disable no-restricted-syntax */
/* eslint-disable guard-for-in */
/* eslint-disable radix */
/* eslint-disable func-names */
/* eslint-disable import/no-mutable-exports */
import { Data } from './data';

const Validator = (function () {
    function validate($element, errorMessage, validateFunc) {
        const value = $element.val();
        if (validateFunc(value)) {
            $element.css('border', '');
            $element.next('span').text('');
            return true;
        }
        $element.css('border', '1px solid #ff6868');
        $element.next('span').text(errorMessage || 'Invalid value!');
        return false;
    }

    function hasMinimumLength(value, minLenght) {
        if (value && value.length >= minLenght) {
            return true;
        }
        return false;
    }

    function hasMaximumLength(value, maxLenght) {
        if (value.length <= maxLenght) {
            return true;
        }
        return false;
    }

    function isAlphaNumeric(value) {
        const pattern = /^([a-z0-9]+)$/i;

        if (value && pattern.test(value)) {
            return true;
        }
        return false;
    }

    function isPassing(value, pattern) {
        if (value && pattern.test(value)) {
            return true;
        }
        return false;
    }

    function isAlphaNumericAndSemicolon(value) {
        const pattern = /^[a-zA-Z0-9;]+$/;

        return isPassing(value, pattern);
    }

    function isUrlFriendly(value) {
        const pattern = /^[a-zA-Z0-9-_]+$/;

        return isPassing(value, pattern);
    }

    function isStartingWithLetter(value) {
        const pattern = /^[a-z]/i;

        if (value && pattern.test(value)) {
            return true;
        }
        return false;
    }

    function validateEmail(value) {
        const pattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/i;
        if (value && pattern.test(value)) {
            return true;
        }
        return false;
    }

    function matchesPattern(value, pattern) {
        if (value && pattern.test(value)) {
            return true;
        }
        return false;
    }

    function isDecimalNumber(value) {
        const pattern = /^\d+\.\d{0,2}$/;
        return matchesPattern(value, pattern);
    }

    function isNumber(value) {
        const pattern = /^-?\d+\.?\d*$/;
        return matchesPattern(value, pattern);
    }

    function isFunction(func) {
        return func && {}.toString.call(func) === '[object Function]';
    }

    function isGuid(stringToTest) {
        let guidString = stringToTest;
        if (stringToTest[0] === '{') {
            guidString = stringToTest.substring(
                1,
                stringToTest.length - 1,
            );
        }
        const regexGuid = /^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$/gi;
        return regexGuid.test(guidString);
    }

    function isInteger(value) {
        return value && parseInt(value) === value;
    }

    function isNumberInRange($element, min, max) {
        if (
            min &&
            !validate(
                $element,
                `The value must be lower or equal to ${max}.`,
                function (value) {
                    return max ? +value <= +max : true;
                },
            )
        ) {
            return false;
        }

        if (
            max &&
            !validate(
                $element,
                `The value must be greater or equal to ${min}.`,
                function (value) {
                    return min ? +value >= +min : true;
                },
            )
        ) {
            return false;
        }

        return true;
    }

    function isLenghtInRange($element, min, max) {
        if (
            min &&
            !validate(
                $element,
                `The value must be at least ${min} characters long.`,
                function (value) {
                    return hasMinimumLength(value, min);
                },
            )
        ) {
            return false;
        }

        if (
            max &&
            !validate(
                $element,
                `The maximum permitted characters length is ${max}.`,
                function (value) {
                    return hasMaximumLength(value, max);
                },
            )
        ) {
            return false;
        }

        return true;
    }

    function validateField($element, customValidationFunc) {
        const validationMessages = {
            required: 'Required field!',
            email: 'Invalid E-Mail!',
            int: 'Not an integer number!',
            number: 'Not a number!',
            guid: 'Invalid guid!',
        };

        const validationTypes = (
            $element.attr('data-validation-type') || ''
        ).split(' ');
        let innerFlag = false;
        const min = $element.attr('data-min');
        const max = $element.attr('data-max');

        for (let i = 0; i < validationTypes.length; i += 1) {
            const validationMessage =
                $element.attr(`data-message-${validationTypes[i]}`) ||
                validationMessages[validationTypes[i]];

            switch (validationTypes[i]) {
                case 'required':
                    if (
                        !validate(
                            $element,
                            validationMessage,
                            function (value) {
                                return !!value;
                            },
                        )
                    ) {
                        innerFlag = true;
                    }

                    break;
                case 'email':
                    if (
                        !validate(
                            $element,
                            validationMessage,
                            validateEmail,
                        )
                    ) {
                        innerFlag = true;
                    }

                    break;
                case 'number':
                    if (
                        !validate(
                            $element,
                            validationMessage,
                            isNumber,
                        )
                    ) {
                        innerFlag = true;
                        break;
                    }

                    innerFlag = !isNumberInRange($element, min, max);
                    break;
                case 'decimal':
                case 'double':
                case 'float':
                    if (
                        !Validator.validate(
                            $element,
                            `${name} must be decimal floating point number!`,
                            (value) => {
                                return (
                                    value &&
                                    parseFloat(value) === value
                                );
                            },
                        )
                    ) {
                        innerFlag = true;
                        break;
                    }

                    innerFlag = !isNumberInRange($element, min, max);
                    break;
                case 'int':
                    if (
                        !validate(
                            $element,
                            validationMessage,
                            isInteger,
                        )
                    ) {
                        innerFlag = true;
                        break;
                    }

                    innerFlag = !isNumberInRange($element, min, max);
                    break;

                case 'guid':
                    if (
                        !validate($element, validationMessage, isGuid)
                    ) {
                        innerFlag = true;
                    }

                    break;
                case 'length':
                    innerFlag = !isLenghtInRange($element, min, max);

                    break;
                default:
                    if (isFunction(customValidationFunc)) {
                        innerFlag = !customValidationFunc($element);
                    }

                    break;
            }

            if (innerFlag) {
                return false;
            }
        }

        return !innerFlag;
    }

    /**
     * Creates a function that will validate all elements with class 'validate' inside the wrapper.
     * @param {Function} customValidationFunc custom validation function for handling specific logic. Will recieve the HTMLElement.
     * Must return true if validation is passing.
     * @returns {Function} Function
     */
    function createFieldsValidation(customValidationFunc) {
        function validateFields(ev) {
            if (!this && !ev && !ev.target) {
                console.error('No HTMLElement has been provided, ');
                return false;
            }

            const $elementsToValidate = $(this || ev.target).find(
                '.validate',
            );
            let flag = false;

            $elementsToValidate.each(function (_, element) {
                const $element = $(element);
                if (!validateField($element, customValidationFunc)) {
                    flag = true;
                }
            });

            return !flag;
        }

        return validateFields;
    }

    function createFieldValidationHandler(customValidationFunc) {
        return function (ev) {
            const $target = ev ? $(ev.target) : $(this);
            validateField($target, customValidationFunc);
        };
    }

    function createValidateOnChangeHandler(
        name,
        url,
        minLenght,
        extraValues,
    ) {
        let timer = 0;

        function validateUrlOnChange(ev) {
            const $input = $(this);
            const min = minLenght || $input.attr('data-min');
            if (timer) {
                clearTimeout(timer);
            }

            let flag = false;
            if (
                min &&
                !Validator.validate(
                    $input,
                    `The value must be atleast ${min} characters long!`,
                    function (val) {
                        return Validator.hasMinimumLength(val, +min);
                    },
                )
            ) {
                flag = true;
            }

            if (!flag) {
                const value = $input.val();
                timer = setTimeout(function () {
                    const body = {};
                    body[name] = value;
                    if (extraValues) {
                        for (const key in extraValues) {
                            body[key] = extraValues[key];
                        }
                    }

                    Data.postJson({ url, data: body }).then(function (
                        res,
                    ) {
                        Validator.validate(
                            $input,
                            res.message ||
                                'Value is invalid or already in use!',
                            function (val) {
                                return res.success;
                            },
                        );
                    },
                    Data.defaultError);
                }, 500);
                $input.next('span').text('');
            }
        }

        return validateUrlOnChange;
    }

    // eslint-disable-next-line no-shadow
    function validateUrl(validateUrl, $urlField, $btnSubmit) {
        // eslint-disable-next-line no-useless-escape
        const pattern = new RegExp(/^[\w\-\.]+$/i);
        if (
            !validate(
                $urlField,
                'Url can only contain letters, numbers, dash(-), point(.) and underscore(_) !',
                (v) => matchesPattern(v, pattern),
            )
        ) {
            $btnSubmit.attr('disabled', true);
            return;
        }

        Data.getJson({ url: validateUrl }).then(function (res) {
            if (
                validate(
                    $urlField,
                    'Url is invalid or already in use!',
                    (v) => res.success,
                )
            ) {
                $btnSubmit.attr('disabled', false);
            } else {
                $btnSubmit.attr('disabled', true);
            }
        });
    }

    function validateUniquenes(name, classToValidate) {
        let counter = 0;
        const $allNames = $(`.${classToValidate}`);
        // eslint-disable-next-line no-param-reassign
        for (name in $allNames) {
            if ($allNames[name].value === name) {
                counter++;
            }
        }

        if (counter > 1) {
            return false;
        }
        return true;
    }

    return {
        validate,
        isAlphaNumeric,
        hasMinimumLength,
        validateEmail,
        isStartingWithLetter,
        isUrlFriendly,
        isNumber,
        isDecimalNumber,
        isAlphaNumericAndSemicolon,
        isFunction,
        isGuid,
        createFieldsValidation,
        isInteger,
        createValidateOnChangeHandler,
        validateField,
        createFieldValidationHandler,
        validateUniquenes,
        validateUrl,
    };
})();

export { Validator };
