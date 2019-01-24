import lib from './lib'
import $ from 'jquery'
import 'bootstrap/dist/css/bootstrap.min.css';
import '../css/site.css';

import React from 'react';
import ReactDOM from 'react-dom';
import Counter from './reactcomponents';

ReactDOM.render(
    <Counter />,
    document.getElementById('basicreactcomponent')
   );

// $('body').html('PESHOOOO');

// document.getElementById("fillthis").innerHTML = getText();

module.hot.accept();