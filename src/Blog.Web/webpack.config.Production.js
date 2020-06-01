const webpack = require('webpack');
const config = require('./webpack.config');

module.exports = {
  mode: 'production',
  entry: config.entry,
  resolve: config.resolve,
  module: config.module,
  plugins: [
    new webpack.ProvidePlugin({
      $: 'jquery',
      jQuery: 'jquery',
    }),
  ],
  output: config.output,
};
