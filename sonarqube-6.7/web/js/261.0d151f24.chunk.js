webpackJsonp([261],{2132:function(t,e,a){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function r(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function o(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}Object.defineProperty(e,"__esModule",{value:!0});var i=a(0),c=a.n(i),l=a(10),s=a(30),u=a.n(s),p=a(2418),f=a(2421),m=a(11),d=a(2),y=a(258),g=a(2713),h=(a.n(g),function(){function t(t,e){for(var a=0;a<e.length;a++){var n=e[a];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}return function(e,a,n){return a&&t(e.prototype,a),n&&t(e,n),e}}()),v=function(t){function e(){return n(this,e),r(this,(e.__proto__||Object.getPrototypeOf(e)).apply(this,arguments))}return o(e,t),h(e,[{key:"componentDidMount",value:function(){this.props.currentUser.isLoggedIn||a.i(y.default)()}},{key:"render",value:function(){var t=this.props,e=t.currentUser,n=t.children;if(!e.isLoggedIn)return null;var r=a.i(d.translate)("my_account.page");return c.a.createElement("div",{id:"account-page"},c.a.createElement(u.a,{defaultTitle:r,titleTemplate:"%s - "+r}),c.a.createElement("header",{className:"account-header"},c.a.createElement("div",{className:"account-container clearfix"},c.a.createElement(f.a,{user:e}),c.a.createElement(p.a,{user:e,customOrganizations:this.props.customOrganizations}))),n)}}]),e}(c.a.PureComponent),b=function(t){return{currentUser:a.i(m.getCurrentUser)(t),customOrganizations:a.i(m.areThereCustomOrganizations)(t)}};e.default=a.i(l.connect)(b)(v)},2418:function(t,e,a){"use strict";function n(t){var e=t.customOrganizations;return o.a.createElement("nav",{className:"account-nav"},o.a.createElement(c.a,null,o.a.createElement("li",null,o.a.createElement(i.IndexLink,{to:"/account/",activeClassName:"active"},a.i(l.translate)("my_account.profile"))),o.a.createElement("li",null,o.a.createElement(i.Link,{to:"/account/security/",activeClassName:"active"},a.i(l.translate)("my_account.security"))),o.a.createElement("li",null,o.a.createElement(i.Link,{to:"/account/notifications",activeClassName:"active"},a.i(l.translate)("my_account.notifications"))),!e&&o.a.createElement("li",null,o.a.createElement(i.Link,{to:"/account/projects/",activeClassName:"active"},a.i(l.translate)("my_account.projects"))),e&&o.a.createElement("li",null,o.a.createElement(i.Link,{to:"/account/organizations",activeClassName:"active"},a.i(l.translate)("my_account.organizations")))))}e.a=n;var r=a(0),o=a.n(r),i=a(9),c=a(404),l=a(2)},2421:function(t,e,a){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function r(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function o(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}var i=a(0),c=a.n(i),l=a(6),s=a.n(l),u=a(62),p=function(){function t(t,e){for(var a=0;a<e.length;a++){var n=e[a];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}return function(e,a,n){return a&&t(e.prototype,a),n&&t(e,n),e}}(),f=function(t){function e(){return n(this,e),r(this,(e.__proto__||Object.getPrototypeOf(e)).apply(this,arguments))}return o(e,t),p(e,[{key:"render",value:function(){var t=this.props.user;return c.a.createElement("div",{className:"account-user"},c.a.createElement("div",{id:"avatar",className:"pull-left account-user-avatar"},c.a.createElement(u.default,{email:t.email,name:t.name,size:60})),c.a.createElement("h1",{id:"name",className:"pull-left"},t.name))}}]),e}(c.a.PureComponent);f.propTypes={user:s.a.object.isRequired},e.a=f},2663:function(t,e,a){e=t.exports=a(27)(void 0),e.push([t.i,'.account-container{width:600px;margin-left:auto;margin-right:auto}.account-header{padding-top:20px;padding-bottom:20px;border-bottom:1px solid #e6e6e6;background-color:#f3f3f3}.account-nav{float:right;padding-top:11px}.account-user{float:left}.account-user h1{line-height:60px}.account-user-avatar{margin-right:20px}.account-user-avatar>img{border-radius:60px}.account-user-avatar:empty{display:none}.account-body{padding:40px 0}.account-separator{height:0;margin:40px 0;border-top:1px solid #e6e6e6}.account-bar-chart .bar-chart-bar{fill:#4b9fd5}.account-bar-chart .bar-chart-tick{fill:#777;font-size:12px;text-anchor:middle}.account-bar-chart .histogram-tick{text-anchor:end}.account-bar-chart .histogram-value{text-anchor:start}.account-projects-list{margin-left:-20px;margin-right:-20px}.account-projects-list>li{padding:15px 20px}.account-projects-list>li+li{border-top:1px solid #e6e6e6}.account-project-side{float:right;margin-left:10px;text-align:right}.account-project-analysis{line-height:24px;color:#777;font-size:12px}.account-project-card{position:relative;display:block}.account-project-name{display:inline-block;vertical-align:top;max-width:300px;overflow:hidden;text-overflow:ellipsis;white-space:nowrap}.account-project-name>a{border-bottom-color:#d0d0d0;color:#444}.account-project-name>a:hover{border-bottom-color:#cae3f2;color:#4b9fd5}.account-project-quality-gate{display:inline-block;vertical-align:top;line-height:24px;margin-left:8px}.account-project-description{margin-top:6px;line-height:1.5}.account-project-links{margin-top:6px}.account-project-key{margin-top:6px;color:#777;font-size:12px}.my-activity-issues{position:relative;display:flex;justify-content:center;margin-bottom:70px}.my-activity-issues:after{position:absolute;z-index:5;top:-15px;left:50%;width:1px;height:100px;background-color:#e6e6e6;transform:rotate(30deg);content:""}.my-activity-issues>a{display:block;padding:15px 20px;border:none;border-radius:2px;color:#444}.my-activity-issues>a:hover{background-color:#f3f3f3}.my-activity-recent-issues{margin-right:50px;text-align:right}.my-activity-recent-issues .my-activity-issues-note{text-align:left}.my-activity-all-issues{margin-left:50px}.my-activity-issues-number{display:inline-block;vertical-align:middle;line-height:36px;font-size:36px;font-weight:300}.my-activity-issues-note{display:inline-block;vertical-align:middle;padding-left:10px;padding-top:2px;line-height:16px;font-size:12px}.my-activity-projects{width:360px;margin:0 auto;padding:40px 0}.my-activity-projects-header{line-height:24px;margin-bottom:15px;padding:0 10px}.my-activity-projects>ul>li+li{border-top:1px solid #e6e6e6}.my-activity-projects>ul>li>a{display:block;padding:15px 10px;border:none}.my-activity-projects>ul>li>a:hover{background-color:#f3f3f3}.my-activity-projects .level{width:60px}.my-activity-projects .more{margin-top:30px;text-align:center}',""])},2713:function(t,e,a){var n=a(2663);"string"==typeof n&&(n=[[t.i,n,""]]);var r={};r.transform=void 0;a(28)(n,r);n.locals&&(t.exports=n.locals)}});
//# sourceMappingURL=261.0d151f24.chunk.js.map