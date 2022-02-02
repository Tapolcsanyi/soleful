import React from "react";
import { Link } from "react-router-dom";
import { Card, CardBody } from "reactstrap";

export const UserSneakerCard = ({ usneaker }) => {
    return (
        <Card>
            <CardBody>
                <Link to={`/sneaker/${usneaker.id}`}>
                    <h3>{usneaker.sneaker.title}</h3>
                </Link>
            </CardBody>
            <CardBody>
                <p>{usneaker.sneaker.shoe}</p>
                <p>{usneaker.sneaker.name}</p>
            </CardBody>
        </Card>)
}

export default UserSneakerCard;