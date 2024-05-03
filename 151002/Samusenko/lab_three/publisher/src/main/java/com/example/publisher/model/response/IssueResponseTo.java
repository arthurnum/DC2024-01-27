package com.example.publisher.model.response;

import java.time.LocalDateTime;

public record IssueResponseTo(
        Long id,
        Long userId,
        String title,
        String content,
        LocalDateTime created,
        LocalDateTime modified
) {
}
