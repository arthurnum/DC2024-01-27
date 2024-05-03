package by.bsuir.discussion.controller;

import by.bsuir.discussion.model.response.NoteResponseTo;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import by.bsuir.discussion.model.request.NoteRequestTo;
import by.bsuir.discussion.service.NoteService;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.validation.Valid;
import java.util.List;
import java.util.Locale;

@RestController
@RequestMapping("/api/v1.0/notes")
@RequiredArgsConstructor
public class NoteController {
    private final NoteService noteService;

    @GetMapping
    public ResponseEntity<List<NoteResponseTo>> getAll() {
        return ResponseEntity.ok(noteService.findAll());
    }

    @PostMapping
    public ResponseEntity<NoteResponseTo> create(@Valid @RequestBody NoteRequestTo dto,
                                                 HttpServletRequest request) {
        final Locale locale = request.getLocale();
        return ResponseEntity.status(HttpStatus.CREATED).body(noteService.create(dto, locale));
    }

    @GetMapping("/{id}")
    public ResponseEntity<NoteResponseTo> get(@Valid @PathVariable("id") Long id) {
        return ResponseEntity.ok(noteService.findById(id));
    }

    @PutMapping
    public ResponseEntity<NoteResponseTo> update(@Valid @RequestBody NoteRequestTo dto) {
        return ResponseEntity.ok(noteService.update(dto));
    }

    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void delete(@Valid @PathVariable("id") Long id) {
        noteService.removeById(id);
    }
}