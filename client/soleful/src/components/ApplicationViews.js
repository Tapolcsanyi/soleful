import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import PostList from "./Post/PostList";
import PostDetails from "./Post/PostDetails";
import TagList from "./Tag/TagList";
import CommentList from "./Comment/CommentList";
import UserProfileList from "./UserProfile/UserProfileList";
import UserProfileDetails from "./UserProfile/UserProfileDetails";
import { TagForm } from "./Tag/CreateTagForm";
import CategoryList from "./Category/CategoryList";
import { CreateCategory } from "./Category/CreateCategoryForm";
import { DeleteTag } from "./Tag/DeleteTag"
import { AddComment } from "./Comment/AddComment";
import { PostForm } from "./Post/CreatePostForm"
import { TagUpdateForm } from "./Tag/UpdateTag"


export default function ApplicationViews({ isLoggedIn }) {

  return (
    <main>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <PostList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/login">
          <Login />
        </Route>

        <Route path="/register">
          <Register />
        </Route>
      </Switch>
    </main>
  );
};
