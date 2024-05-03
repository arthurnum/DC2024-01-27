package by.bsuir.restapi.repository;

import by.bsuir.restapi.model.entity.Marker;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface MarkerRepository extends JpaRepository<Marker, Long> {
}
