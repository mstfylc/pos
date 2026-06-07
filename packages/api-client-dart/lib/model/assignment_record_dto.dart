//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'assignment_record_dto.g.dart';

abstract class AssignmentRecordDto implements Built<AssignmentRecordDto, AssignmentRecordDtoBuilder> {

    @BuiltValueField(wireName: r'recordId')
    String get recordId;

    @BuiltValueField(wireName: r'recordName')
    String get recordName;

    AssignmentRecordDto._();

    static void _initializeBuilder(AssignmentRecordDtoBuilder b) => b;

    factory AssignmentRecordDto([void updates(AssignmentRecordDtoBuilder b)]) = _$AssignmentRecordDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<AssignmentRecordDto> get serializer => _$AssignmentRecordDtoSerializer();
}

class _$AssignmentRecordDtoSerializer implements StructuredSerializer<AssignmentRecordDto> {

    @override
    final Iterable<Type> types = const [AssignmentRecordDto, _$AssignmentRecordDto];
    @override
    final String wireName = r'AssignmentRecordDto';

    @override
    Iterable<Object> serialize(Serializers serializers, AssignmentRecordDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'recordId')
            ..add(serializers.serialize(object.recordId,
                specifiedType: const FullType(String)));
        result
            ..add(r'recordName')
            ..add(serializers.serialize(object.recordName,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    AssignmentRecordDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AssignmentRecordDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'recordId':
                    result.recordId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'recordName':
                    result.recordName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

