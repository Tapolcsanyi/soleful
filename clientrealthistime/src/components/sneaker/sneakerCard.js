import React from "react";
import { Link } from "react-router-dom";
import { Card, CardBody, Button } from "reactstrap";
import { addUserSneaker } from "../../modules/userSneakerManager";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom/cjs/react-router-dom.min";
import { getUserProfileByFirebaseId, getUserProfileById } from "../../modules/userManager";
import firebase from "firebase";
import { getLoggedInUser } from "../../modules/userManager";

export const SneakerCard = ({ sneaker, handleDeleteSneaker }) => {

    const [user, setUser] = useState({});
    const [userSneaker, setUserSneaker] = useState({
        SneakerId: 0
    });

    const history = useHistory();

    useEffect(() => {
        getLoggedInUser().then(user => setUser(user))
    }, []);

    const onClickAddUserSneaker = (event) => {
        const newUserSneaker = { ...userSneaker }
        let selectedVal = event.target.value
        if (event.target.id.includes("Id")) {
            selectedVal = parseInt(selectedVal)
        }
        newUserSneaker[event.target.id] = selectedVal
        setUserSneaker(newUserSneaker)
        console.log(newUserSneaker)
        addUserSneaker(newUserSneaker)
    }

    const handleEditSneaker = () => {
        history.push(`/sneakereditform/${sneaker.id}`);
    };

    if(user.userTypeId == 1){
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
                <Button onClick={onClickAddUserSneaker} id="SneakerId" value={sneaker.id}>Add to My Collection</Button>
                <Button onClick={() => handleDeleteSneaker(sneaker.id)}>Delete Sneaker</Button>
                <Button onClick={handleEditSneaker} id="SneakerId" value={sneaker.id}>Edit Sneaker</Button>
            </Card>)
    } else {
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
            <Button onClick={onClickAddUserSneaker} id="SneakerId" value={sneaker.id}>Add to My Collection</Button>
        </Card>)
    }
}

export default SneakerCard;