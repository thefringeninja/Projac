#!/usr/bin/env bash
shopt -s globstar

for file in **/*.cs; do
  # Remove the NET46/NET452 section
  sed -i '/#if NET46\|#if NET452/,/#else/{/#else/!d}' "$file"

  # Remove the preprocessor lines
  sed -i '/#else/d' "$file"
  sed -i '/#endif/d' "$file"
  sed -i '/#if NET46\|#if NET452/d' "$file"
done

