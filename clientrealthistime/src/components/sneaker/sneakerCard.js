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
import './sneaker.css'

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
        console.log(sneaker.image)
        var popup = document.getElementById("myPopup");
        popup.classList.toggle("show");
    }

    const handleEditSneaker = () => {
        history.push(`/sneakereditform/${sneaker.id}`);
    };

    if(user.userTypeId == 1){
        return (
            <div  className=""> 
            <Card className="cardBody">
            <CardBody>
            <img className="sneakerImg" src={sneaker.image}></img>
                <Link to={`/sneaker/${sneaker.id}`}>
                    <h3>{sneaker.title}</h3>
                </Link>
                <h3>Retail Price: ${sneaker.retailPrice}</h3>
                <Button className="sneakerButton2" onClick={onClickAddUserSneaker} id="SneakerId" value={sneaker.id}>Add to My Collection</Button>
                <Button className="sneakerButton2" onClick={() => handleDeleteSneaker(sneaker.id)}>Delete Sneaker</Button>
                <Button className="sneakerButton2" onClick={handleEditSneaker} id="SneakerId" value={sneaker.id}>Edit Sneaker</Button>
                </CardBody>
            </Card>
            </div>)
    } else {
    return (
        <div className="">
        <Card className="cardBody">
            <CardBody>
            <img className="sneakerImg" src={sneaker.image}></img>
                <Link to={`/sneaker/${sneaker.id}`}>
                    <h3>{sneaker.title}</h3>
                </Link>
                <h3>Retail Price: ${sneaker.retailPrice}</h3>
                <Button className="sneakerButton" onClick={onClickAddUserSneaker} id="SneakerId" value={sneaker.id}>Add to My Collection</Button>
            </CardBody>
        </Card>
        </div>)
    }
}

export default SneakerCard;