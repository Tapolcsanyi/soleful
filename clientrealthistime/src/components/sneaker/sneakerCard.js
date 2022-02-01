import React from "react";
import { Link } from "react-router-dom";
import { Card, CardBody } from "reactstrap";

export const SneakerCard = ({ sneaker }) => {
    return (
        <Card>
            <CardBody>
                <Link to={`/sneaker/${sneaker.id}`}>
                    <h3>{sneaker.title}</h3>
                </Link>
            </CardBody>
            <CardBody>
                <p>{sneaker.shoe}</p>
                <p>{sneaker.name}</p>
            </CardBody>
        </Card>)
}

export default SneakerCard;