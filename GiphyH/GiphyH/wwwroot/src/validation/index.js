// eslint-disable-next-line no-confusing-arrow
export const minLength = min => value => !value || value.length < min ? `Must be ${min} characters or more` : undefined
