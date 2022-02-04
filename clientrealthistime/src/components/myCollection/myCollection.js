import React, { useEffect, useState } from "react";
import { getAllUserSneakers } from '../../modules/userSneakerManager';
import { UserSneakerCard } from "./userSneakerCard";
import { deleteUserSneaker } from "../../modules/userSneakerManager";

export const UserSneakerList = () => {
    const [sneakers, setSneakers] = useState([]);

    const getSneakers = () => {
        return getAllUserSneakers().then(sneakers => {
            setSneakers(sneakers)
        });
    };

    const handleDeleteSneaker = (sneakerid) => {
        deleteUserSneaker(sneakerid).then(res => (
            getSneakers()
            .then (res =>
                console.log(res))
        ))
    }

    useEffect(() => {
        getSneakers();
    }, []);

    console.log(sneakers)

    return (
        <> <div>
            <div>{sneakers.map(usneaker => <UserSneakerCard key={usneaker.id} usneaker={usneaker} handleDeleteSneaker={handleDeleteSneaker}/>)}</div>
        </div>
        </>
    )
}
export default UserSneakerList;