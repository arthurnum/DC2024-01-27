package by.bashlikovvv.api.dto.request

import by.bashlikovvv.util.inRange
import kotlinx.serialization.Serializable

@Serializable
data class CreatePostDto @Throws(IllegalArgumentException::class) constructor(
    val id: Long? = null,
    val tweetId: Long,
    val content: String
) {
    init {
        require(content.inRange(2, 2048))
    }

}