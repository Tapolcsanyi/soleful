import React, { useState } from 'react';
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink
} from 'reactstrap';
import { logout } from '../modules/authManager';
import firebase from "firebase";
import 'firebase/auth'; //v9
import 'firebase/firestore'; //v9
import '../index.css'

export default function Header({ isLoggedIn }) {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);

  const user = firebase.auth().currentUser;

  return (
    <div>
      <Navbar className="navLink2" color="light" light expand="md">
        <NavbarBrand className='navLink' tag={RRNavLink} to="/">Soleful</NavbarBrand>
        <Collapse className='navBar' isOpen={isOpen} navbar>
          <Nav className='navContainer' navbar>
            { /* When isLoggedIn === true, we will render the Home link */}
            {isLoggedIn &&
              <>
                <NavItem className="navItem">
                  <NavLink className="navLink" tag={RRNavLink} to="/">Shoes</NavLink>
                </NavItem>
                <NavItem className="navItem">
                  <NavLink className="navLink" tag={RRNavLink} to="/mycollection">My Collection</NavLink>
                </NavItem>
                <NavItem className="navItem">
                  <NavLink className="navLink" tag={RRNavLink} to="/lists">My Lists</NavLink>
                </NavItem></>
            }
          </Nav>
          <Nav className='navContainer' navbar>
            {isLoggedIn &&
              <>
                <NavItem className='navItem'>
                  <a className="navLink" aria-current="page"
                    style={{ cursor: "pointer" }} onClick={logout}>Logout</a>
                </NavItem>
              </>
            }
            {!isLoggedIn &&
              <>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/login">Login</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/register">Register</NavLink>
                </NavItem>
              </>
            }
          </Nav>
        </Collapse>
      </Navbar>
    </div>
  );
}